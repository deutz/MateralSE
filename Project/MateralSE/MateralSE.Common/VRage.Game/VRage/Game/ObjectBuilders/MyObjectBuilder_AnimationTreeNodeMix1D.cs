﻿namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AnimationTreeNodeMix1D : MyObjectBuilder_AnimationTreeNode
    {
        [ProtoMember(0xd8)]
        public string ParameterName;
        [ProtoMember(0xde)]
        public bool Circular;
        [ProtoMember(0xe4)]
        public float Sensitivity = 1f;
        [ProtoMember(0xea)]
        public float? MaxChange;
        [ProtoMember(240), XmlElement("Child")]
        public MyParameterAnimTreeNodeMapping[] Children;

        protected internal override MyObjectBuilder_AnimationTreeNode DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes, MyObjectBuilder_AnimationTreeNode parentNode, List<MyObjectBuilder_AnimationTreeNode> orphans)
        {
            bool flag = (selectedNodes == null) || selectedNodes.Contains(this);
            MyObjectBuilder_AnimationTreeNodeMix1D item = new MyObjectBuilder_AnimationTreeNodeMix1D {
                ParameterName = this.ParameterName,
                Circular = this.Circular,
                Sensitivity = this.Sensitivity,
                MaxChange = this.MaxChange,
                Children = null,
                EdPos = base.EdPos
            };
            if (this.Children != null)
            {
                item.Children = new MyParameterAnimTreeNodeMapping[this.Children.Length];
                for (int i = 0; i < this.Children.Length; i++)
                {
                    MyObjectBuilder_AnimationTreeNode node = null;
                    if (this.Children[i].Node != null)
                    {
                        node = this.Children[i].Node.DeepCopyWithMask(selectedNodes, flag ? item : null, orphans);
                    }
                    item.Children[i].Param = this.Children[i].Param;
                    item.Children[i].Node = node;
                }
            }
            if (!flag)
            {
                return null;
            }
            if (parentNode == null)
            {
                orphans.Add(item);
            }
            return item;
        }

        public override MyObjectBuilder_AnimationTreeNode[] GetChildren()
        {
            if (this.Children != null)
            {
                List<MyObjectBuilder_AnimationTreeNode> list = new List<MyObjectBuilder_AnimationTreeNode>();
                int index = 0;
                while (true)
                {
                    if (index >= this.Children.Length)
                    {
                        if (list.Count <= 0)
                        {
                            break;
                        }
                        return list.ToArray();
                    }
                    if (this.Children[index].Node != null)
                    {
                        list.Add(this.Children[index].Node);
                    }
                    index++;
                }
            }
            return null;
        }
    }
}

