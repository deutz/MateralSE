﻿namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxNewListNode : MyVisualSyntaxNode
    {
        public MyVisualSyntaxNewListNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            object obj1;
            base.CollectInputExpressions(expressions);
            Type type = MyVisualScriptingProxy.GetType(this.ObjectBuilder.Type);
            Type[] typeArguments = new Type[] { type };
            Type type2 = typeof(List<>).MakeGenericType(typeArguments);
            List<SyntaxNodeOrToken> list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < this.ObjectBuilder.DefaultEntries.Count; i++)
            {
                string val = this.ObjectBuilder.DefaultEntries[i];
                LiteralExpressionSyntax syntax4 = MySyntaxFactory.Literal(this.ObjectBuilder.Type, val);
                list.Add(syntax4);
                if (i < (this.ObjectBuilder.DefaultEntries.Count - 1))
                {
                    list.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                }
            }
            ArrayCreationExpressionSyntax syntax = null;
            if (list.Count > 0)
            {
                syntax = SyntaxFactory.ArrayCreationExpression(SyntaxFactory.ArrayType(SyntaxFactory.IdentifierName(this.ObjectBuilder.Type), SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>(SyntaxFactory.ArrayRankSpecifier(SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(SyntaxFactory.OmittedArraySizeExpression())))), SyntaxFactory.InitializerExpression(SyntaxKind.ArrayInitializerExpression, SyntaxFactory.SeparatedList<ExpressionSyntax>(list)));
            }
            if (syntax == null)
            {
                obj1 = null;
            }
            else
            {
                ArrayCreationExpressionSyntax[] syntaxArray1 = new ArrayCreationExpressionSyntax[] { syntax };
                obj1 = syntaxArray1;
            }
            ObjectCreationExpressionSyntax initializerExpressionSyntax = MySyntaxFactory.GenericObjectCreation(type2, (IEnumerable<ExpressionSyntax>) obj1);
            LocalDeclarationStatementSyntax item = MySyntaxFactory.LocalVariable(type2, this.VariableSyntaxName(null), initializerExpressionSyntax);
            expressions.Add(item);
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                foreach (MyVariableIdentifier identifier in this.ObjectBuilder.Connections)
                {
                    base.TryRegisterNode(identifier.NodeID, this.Outputs);
                }
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            ("newListNode_" + this.ObjectBuilder.ID);

        public MyObjectBuilder_NewListScriptNode ObjectBuilder =>
            ((MyObjectBuilder_NewListScriptNode) base.m_objectBuilder);

        internal override bool SequenceDependent =>
            false;
    }
}

