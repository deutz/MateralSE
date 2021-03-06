﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_TutorialsHelper : MyObjectBuilder_Base
    {
        [ProtoMember(0x17), XmlArrayItem("Tutorial")]
        public MyTutorialDescription[] Tutorials;
    }
}

