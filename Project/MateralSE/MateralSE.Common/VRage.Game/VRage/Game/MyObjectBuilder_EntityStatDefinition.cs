﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EntityStatDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x25)]
        public float MinValue;
        [ProtoMember(40)]
        public float MaxValue = 100f;
        [ProtoMember(0x2b)]
        public float DefaultValue = float.NaN;
        [ProtoMember(0x2e), XmlAttribute(AttributeName="EnabledInCreative")]
        public bool EnabledInCreative = true;
        [ProtoMember(0x31)]
        public string Name = string.Empty;
        [ProtoMember(0x34)]
        public GuiDefinition GuiDef = new GuiDefinition();

        [ProtoContract]
        public class GuiDefinition
        {
            [ProtoMember(15)]
            public float HeightMultiplier = 1f;
            [ProtoMember(0x12)]
            public int Priority = 1;
            [ProtoMember(0x15)]
            public SerializableVector3I Color = new SerializableVector3I(0xff, 0xff, 0xff);
            [ProtoMember(0x18)]
            public float CriticalRatio;
            [ProtoMember(0x1b)]
            public bool DisplayCriticalDivider;
            [ProtoMember(30)]
            public SerializableVector3I CriticalColorFrom = new SerializableVector3I(0x9b, 0, 0);
            [ProtoMember(0x21)]
            public SerializableVector3I CriticalColorTo = new SerializableVector3I(0xff, 0, 0);
        }
    }
}

