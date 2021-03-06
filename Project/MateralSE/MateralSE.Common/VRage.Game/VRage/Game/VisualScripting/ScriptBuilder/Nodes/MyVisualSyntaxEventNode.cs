﻿namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.VisualScripting;

    public class MyVisualSyntaxEventNode : MyVisualSyntaxNode, IMyVisualSyntaxEntryPoint
    {
        private MyVisualSyntaxNode m_nextSequenceNode;
        protected FieldInfo m_fieldInfo;

        public MyVisualSyntaxEventNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
            if (!(this.ObjectBuilder is MyObjectBuilder_InputScriptNode))
            {
                this.m_fieldInfo = MyVisualScriptingProxy.GetField(this.ObjectBuilder.Name);
            }
        }

        public void AddSequenceInput(MyVisualSyntaxNode node)
        {
            this.SequenceInputs.Add(node);
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed && (this.ObjectBuilder.SequenceOutputID != -1))
            {
                this.m_nextSequenceNode = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceOutputID);
                this.SequenceOutputs.Add(this.m_nextSequenceNode);
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null)
        {
            using (List<string>.Enumerator enumerator = this.ObjectBuilder.OutputNames.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    if (enumerator.Current == variableIdentifier)
                    {
                        return variableIdentifier;
                    }
                }
            }
            return null;
        }

        public MyObjectBuilder_EventScriptNode ObjectBuilder =>
            ((MyObjectBuilder_EventScriptNode) base.m_objectBuilder);

        public virtual string EventName =>
            this.m_fieldInfo.Name;
    }
}

