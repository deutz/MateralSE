﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_TriggerNoSpawn : MyObjectBuilder_Trigger
    {
        [ProtoMember(11)]
        public int Limit;
    }
}

