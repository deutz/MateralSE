﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_MultiBlockDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("BlockDefinition"), ProtoMember(0x1b), DefaultValue((string) null)]
        public MyOBMultiBlockPartDefinition[] BlockDefinitions;

        [ProtoContract]
        public class MyOBMultiBlockPartDefinition
        {
            [ProtoMember(0x10)]
            public SerializableDefinitionId Id;
            [ProtoMember(0x13)]
            public SerializableVector3I Position;
            [ProtoMember(0x16)]
            public SerializableBlockOrientation Orientation;
        }
    }
}

