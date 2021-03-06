﻿namespace VRage.Game.VisualScripting.ScriptBuilder
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Emit;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;
    using VRage.FileSystem;
    using VRage.Game.VisualScripting;

    public class MyVSCompiler
    {
        public static MyDependencyCollector DependencyCollector = new MyDependencyCollector();
        private static readonly CSharpCompilationOptions m_defaultCompilationOptions;
        public readonly List<string> SourceFiles;
        public readonly List<string> SourceTexts;
        private CSharpCompilation m_compilation;
        private System.Reflection.Assembly m_compiledAndLoadedAssembly;

        static MyVSCompiler()
        {
            System.Collections.Immutable.ImmutableArray<byte> array = new System.Collections.Immutable.ImmutableArray<byte>();
            bool? nullable = null;
            m_defaultCompilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, false, null, null, null, null, OptimizationLevel.Debug, false, false, null, null, array, nullable, Platform.AnyCpu, ReportDiagnostic.Default, 4, null, true, false, null, null, null, null, null, false).WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release);
        }

        public MyVSCompiler(string assemblyName)
        {
            this.SourceFiles = new List<string>();
            this.SourceTexts = new List<string>();
            this.AssemblyName = assemblyName;
        }

        public MyVSCompiler(string assemblyName, IEnumerable<string> sourceFiles) : this(assemblyName)
        {
            this.SourceFiles.AddRange(sourceFiles);
        }

        public bool Compile()
        {
            if ((this.SourceFiles.Count == 0) && (this.SourceTexts.Count == 0))
            {
                return false;
            }
            SyntaxTree[] treeArray = new SyntaxTree[this.SourceFiles.Count + this.SourceTexts.Count];
            int index = 0;
            try
            {
                CancellationToken token;
                using (List<string>.Enumerator enumerator = this.SourceFiles.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        StreamReader reader = new StreamReader(MyFileSystem.OpenRead(enumerator.Current));
                        try
                        {
                            token = new CancellationToken();
                            treeArray[index] = CSharpSyntaxTree.ParseText(reader.ReadToEnd(), null, "", null, token);
                            index++;
                        }
                        finally
                        {
                            if (reader == null)
                            {
                                continue;
                            }
                            reader.Dispose();
                        }
                    }
                }
                foreach (string str2 in this.SourceTexts)
                {
                    index++;
                    token = new CancellationToken();
                    treeArray[index] = CSharpSyntaxTree.ParseText(str2, null, "", null, token);
                }
                this.m_compilation = CSharpCompilation.Create(this.AssemblyName, treeArray, DependencyCollector.References, m_defaultCompilationOptions);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public string GetDiagnosticMessage()
        {
            CancellationToken token = new CancellationToken();
            System.Collections.Immutable.ImmutableArray<Diagnostic> diagnostics = this.m_compilation.GetDiagnostics(token);
            if (diagnostics.IsDefaultOrEmpty)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            System.Collections.Immutable.ImmutableArray<Diagnostic>.Enumerator enumerator = diagnostics.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Diagnostic current = enumerator.Current;
                if (current.Severity == DiagnosticSeverity.Error)
                {
                    builder.AppendLine(current.ToString());
                }
            }
            return builder.ToString();
        }

        public List<IMyLevelScript> GetLevelScriptInstances()
        {
            List<IMyLevelScript> list = new List<IMyLevelScript>();
            if (this.m_compiledAndLoadedAssembly != null)
            {
                foreach (Type type in this.m_compiledAndLoadedAssembly.GetTypes())
                {
                    if (typeof(IMyLevelScript).IsAssignableFrom(type))
                    {
                        list.Add((IMyLevelScript) Activator.CreateInstance(type));
                    }
                }
            }
            return list;
        }

        public bool LoadAssembly()
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (MemoryStream stream2 = new MemoryStream())
                    {
                        CancellationToken token = new CancellationToken();
                        EmitResult result = this.m_compilation.Emit(stream, stream2, null, null, null, null, null, token);
                        if (!result.Success)
                        {
                            bool flag;
                            StringBuilder builder = new StringBuilder();
                            System.Collections.Immutable.ImmutableArray<Diagnostic>.Enumerator enumerator = result.Diagnostics.GetEnumerator();
                            while (true)
                            {
                                if (!enumerator.MoveNext())
                                {
                                    flag = false;
                                    break;
                                }
                                Diagnostic current = enumerator.Current;
                                string text = string.Empty;
                                token = new CancellationToken();
                                foreach (SyntaxNode node in current.Location.SourceTree.GetRoot(token).DescendantNodes((Func<SyntaxNode, bool>) null, false))
                                {
                                    if (node is ClassDeclarationSyntax)
                                    {
                                        text = ((ClassDeclarationSyntax) node).Identifier.Text;
                                        break;
                                    }
                                }
                                builder.AppendLine(text + ": " + current);
                            }
                            return flag;
                        }
                        else
                        {
                            this.m_compiledAndLoadedAssembly = System.Reflection.Assembly.Load(stream.ToArray(), stream2.ToArray());
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public string AssemblyName { get; private set; }

        public System.Reflection.Assembly Assembly =>
            this.m_compiledAndLoadedAssembly;
    }
}

