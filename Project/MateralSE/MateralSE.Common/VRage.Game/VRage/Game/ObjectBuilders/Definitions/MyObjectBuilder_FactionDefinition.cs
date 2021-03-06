﻿namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_FactionDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(12), XmlAttribute]
        public string Tag;
        [ProtoMember(0x10), XmlAttribute]
        public string Name;
        [ProtoMember(20), XmlAttribute]
        public string Founder;
        [ProtoMember(0x18)]
        public bool AcceptHumans;
        [ProtoMember(0x1b)]
        public bool AutoAcceptMember = true;
        [ProtoMember(30)]
        public bool EnableFriendlyFire;
        [ProtoMember(0x25)]
        public bool IsDefault;
        [ProtoMember(0x2c)]
        public MyRelationsBetweenFactions DefaultRelation = MyRelationsBetweenFactions.Enemies;
    }
}

