﻿namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_FractureComponentBase : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(0x17)]
        public List<FracturedShape> Shapes = new List<FracturedShape>();

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct FracturedShape
        {
            [ProtoMember(0x10)]
            public string Name;
            [ProtoMember(0x13), DefaultValue(false)]
            public bool Fixed;
        }
    }
}

