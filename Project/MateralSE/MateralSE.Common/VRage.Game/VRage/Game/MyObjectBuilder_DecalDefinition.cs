﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageRender;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_DecalDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(12)]
        public MyDecalMaterialDesc Material;
        [ProtoMember(15)]
        public string Target = string.Empty;
        [ProtoMember(0x12)]
        public string Source = string.Empty;
        [ProtoMember(0x15)]
        public float MinSize = 1f;
        [ProtoMember(0x18)]
        public float MaxSize = 2f;
        [ProtoMember(0x1b)]
        public float Depth = 0.2f;
        [ProtoMember(30)]
        public float Rotation = float.PositiveInfinity;
        [ProtoMember(0x21)]
        public bool Transparent;
    }
}

