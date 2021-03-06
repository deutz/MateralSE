﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct SerializableLineSectionInformation
    {
        [ProtoMember(10), XmlAttribute]
        public VRageMath.Base6Directions.Direction Direction;
        [ProtoMember(13), XmlAttribute]
        public int Length;
    }
}

