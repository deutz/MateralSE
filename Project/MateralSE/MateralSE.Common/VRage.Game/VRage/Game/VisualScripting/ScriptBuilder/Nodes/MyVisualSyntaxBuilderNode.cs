﻿namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;

    public class MyVisualSyntaxBuilderNode : MyVisualSyntaxNode
    {
        public MyVisualSyntaxBuilderNode() : base(null)
        {
        }

        public void Preprocess()
        {
            base.Depth = 0;
            base.Navigator.FreshNodes.Clear();
            this.Preprocess(base.Depth + 1);
            foreach (MyVisualSyntaxNode node in base.Navigator.FreshNodes)
            {
                if (node.Outputs.Count == 1)
                {
                    node.Outputs[0].SubTreeNodes.Add(node);
                    continue;
                }
                MyVisualSyntaxNode node2 = CommonParent(node.GetSequenceDependentOutputs());
                if (node2 == null)
                {
                    base.SubTreeNodes.Add(node);
                    continue;
                }
                node2.SubTreeNodes.Add(node);
            }
        }
    }
}

