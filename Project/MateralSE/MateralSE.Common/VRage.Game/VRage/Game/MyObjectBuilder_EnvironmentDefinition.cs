﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Data;
    using VRage.ObjectBuilders;
    using VRageMath;
    using VRageRender;
    using VRageRender.Messages;

    [MyObjectBuilderDefinition((Type) null, null), XmlType("EnvironmentDefinition"), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EnvironmentDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyFogProperties>))]
        public MyFogProperties FogProperties = MyFogProperties.Default;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyPlanetProperties>))]
        public MyPlanetProperties PlanetProperties = MyPlanetProperties.Default;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MySunProperties>))]
        public MySunProperties SunProperties = MySunProperties.Default;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyPostprocessSettings>))]
        public MyPostprocessSettings PostProcessSettings = MyPostprocessSettings.Default;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MySSAOSettings>))]
        public MySSAOSettings SSAOSettings = MySSAOSettings.Default;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyHBAOData>))]
        public MyHBAOData HBAOSettings = MyHBAOData.Default;
        public MyShadowsSettings ShadowSettings = new MyShadowsSettings();
        public MyNewLoddingSettings LowLoddingSettings = new MyNewLoddingSettings();
        public MyNewLoddingSettings MediumLoddingSettings = new MyNewLoddingSettings();
        public MyNewLoddingSettings HighLoddingSettings = new MyNewLoddingSettings();
        public MyNewLoddingSettings ExtremeLoddingSettings = new MyNewLoddingSettings();
        [ProtoMember(0x4e), XmlArrayItem("ParticleType")]
        public List<EnvironmentalParticleSettings> EnvironmentalParticles = new List<EnvironmentalParticleSettings>();
        public float SmallShipMaxSpeed = 100f;
        public float LargeShipMaxSpeed = 100f;
        public float SmallShipMaxAngularSpeed = 36000f;
        public float LargeShipMaxAngularSpeed = 18000f;
        public Vector4 ContourHighlightColor = Defaults.ContourHighlightColor;
        public Vector4 ContourHighlightColorAccessDenied = Defaults.ContourHighlightColorAccessDenied;
        public float ContourHighlightThickness = 5f;
        public float HighlightPulseInSeconds;
        [ModdableContentFile("dds")]
        public string EnvironmentTexture = @"Textures\BackgroundCube\Final\BackgroundCube.dds";
        public MyOrientation EnvironmentOrientation = Defaults.EnvironmentOrientation;

        public static class Defaults
        {
            public const float SmallShipMaxSpeed = 100f;
            public const float LargeShipMaxSpeed = 100f;
            public const float SmallShipMaxAngularSpeed = 36000f;
            public const float LargeShipMaxAngularSpeed = 18000f;
            public static readonly Vector4 ContourHighlightColor = new Vector4(1f, 1f, 0f, 0.05f);
            public static readonly Vector4 ContourHighlightColorAccessDenied = new Vector4(1f, 0f, 0f, 0.05f);
            public const float ContourHighlightThickness = 5f;
            public const float HighlightPulseInSeconds = 0f;
            public const string EnvironmentTexture = @"Textures\BackgroundCube\Final\BackgroundCube.dds";
            public static readonly MyOrientation EnvironmentOrientation = new MyOrientation(MathHelper.ToRadians((float) 60.39555f), MathHelper.ToRadians((float) -61.1862f), MathHelper.ToRadians((float) 90.90578f));
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct EnvironmentalParticleSettings
        {
            [ProtoMember(0x2f)]
            public SerializableDefinitionId Id;
            [ProtoMember(50)]
            public string Material;
            [ProtoMember(0x35)]
            public Vector4 Color;
            [ProtoMember(0x38)]
            public string MaterialPlanet;
            [ProtoMember(0x3b)]
            public Vector4 ColorPlanet;
            [ProtoMember(0x3e)]
            public float MaxSpawnDistance;
            [ProtoMember(0x41)]
            public float DespawnDistance;
            [ProtoMember(0x44)]
            public float Density;
            [ProtoMember(0x47)]
            public int MaxLifeTime;
            [ProtoMember(0x4a)]
            public int MaxParticles;
        }
    }
}

