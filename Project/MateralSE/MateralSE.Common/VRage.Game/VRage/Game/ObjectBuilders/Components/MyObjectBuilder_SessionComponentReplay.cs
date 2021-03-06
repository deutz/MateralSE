﻿namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilder;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_SessionComponentReplay : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(0x12)]
        public MySerializableList<PerEntityData> EntityReplayData = new MySerializableList<PerEntityData>();
    }
}

