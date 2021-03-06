﻿namespace VRage.Game.ObjectBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using VRage;
    using VRage.Game;
    using VRage.ObjectBuilders;
    using VRage.Plugins;

    public class MyGlobalTypeMetadata
    {
        public static MyGlobalTypeMetadata Static = new MyGlobalTypeMetadata();
        private HashSet<Assembly> m_assemblies = new HashSet<Assembly>();
        private bool m_ready;

        public Type GetType(string fullName, bool throwOnError)
        {
            using (HashSet<Assembly>.Enumerator enumerator = this.m_assemblies.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    Type type = enumerator.Current.GetType(fullName, false);
                    if (type != null)
                    {
                        return type;
                    }
                }
            }
            if (throwOnError)
            {
                throw new TypeLoadException($"Type {fullName} was not found in any registered assembly!");
            }
            return null;
        }

        public void Init(bool loadSerializersAsync = true)
        {
            if (!this.m_ready)
            {
                MyXmlSerializerManager.RegisterSerializableBaseType(typeof(MyObjectBuilder_Base));
                this.RegisterAssembly(base.GetType().Assembly);
                this.RegisterAssembly(MyPlugins.GameAssembly);
                this.RegisterAssembly(MyPlugins.SandboxGameAssembly);
                this.RegisterAssembly(MyPlugins.SandboxAssembly);
                this.RegisterAssembly(MyPlugins.UserAssemblies);
                this.RegisterAssembly(MyPlugins.GameBaseObjectBuildersAssembly);
                this.RegisterAssembly(MyPlugins.GameObjectBuildersAssembly);
                foreach (IPlugin plugin in MyPlugins.Plugins)
                {
                    this.RegisterAssembly(plugin.GetType().Assembly);
                }
                if (loadSerializersAsync)
                {
                    Task.Factory.StartNew(() => MyObjectBuilderSerializer.LoadSerializers());
                }
                else
                {
                    MyObjectBuilderSerializer.LoadSerializers();
                }
                this.m_ready = true;
            }
        }

        public void RegisterAssembly(Assembly[] assemblies)
        {
            if (assemblies != null)
            {
                foreach (Assembly assembly in assemblies)
                {
                    this.RegisterAssembly(assembly);
                }
            }
        }

        public void RegisterAssembly(Assembly assembly)
        {
            if (assembly != null)
            {
                this.m_assemblies.Add(assembly);
                MyObjectBuilderSerializer.RegisterFromAssembly(assembly);
                MyObjectBuilderType.RegisterFromAssembly(assembly, true);
                MyXmlSerializerManager.RegisterFromAssembly(assembly);
                MyDefinitionManagerBase.RegisterTypesFromAssembly(assembly);
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly MyGlobalTypeMetadata.<>c <>9 = new MyGlobalTypeMetadata.<>c();
            public static Action <>9__6_0;

            internal void <Init>b__6_0()
            {
                MyObjectBuilderSerializer.LoadSerializers();
            }
        }
    }
}

