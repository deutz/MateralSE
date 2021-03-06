﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Sector : MyObjectBuilder_Base
    {
        [ProtoMember(14)]
        public Vector3I Position;
        [ProtoMember(0x18)]
        public MyObjectBuilder_GlobalEvents SectorEvents;
        [ProtoMember(0x1b)]
        public int AppVersion;
        [ProtoMember(30), Obsolete]
        public MyObjectBuilder_Encounters Encounters;
        [ProtoMember(0x22)]
        public MyObjectBuilder_EnvironmentSettings Environment;
        [ProtoMember(0x26)]
        public ulong VoxelHandVolumeChanged;

        public bool ShouldSerializeEnvironment() => 
            (this.Environment != null);

        [ProtoMember(0x11), DynamicObjectBuilder(false), XmlArrayItem("MyObjectBuilder_EntityBase", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EntityBase>))]
        public List<MyObjectBuilder_EntityBase> SectorObjects { get; set; }
    }
}

