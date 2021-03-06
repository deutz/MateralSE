﻿namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ProjectileAmmoDefinition : MyObjectBuilder_AmmoDefinition
    {
        [ProtoMember(0x31), DefaultValue((string) null)]
        public AmmoProjectileProperties ProjectileProperties;

        [ProtoContract]
        public class AmmoProjectileProperties
        {
            [ProtoMember(15)]
            public float ProjectileHitImpulse;
            [ProtoMember(0x12), DefaultValue((float) 0.1f)]
            public float ProjectileTrailScale = 0.1f;
            [ProtoMember(0x15)]
            public SerializableVector3 ProjectileTrailColor = new SerializableVector3(1f, 1f, 1f);
            [ProtoMember(0x18), DefaultValue((string) null)]
            public string ProjectileTrailMaterial;
            [ProtoMember(0x1b), DefaultValue((float) 0.5f)]
            public float ProjectileTrailProbability = 0.5f;
            [ProtoMember(30)]
            public string ProjectileOnHitEffectName = "Hit_BasicAmmoSmall";
            [ProtoMember(0x21)]
            public float ProjectileMassDamage;
            [ProtoMember(0x24)]
            public float ProjectileHealthDamage;
            [ProtoMember(0x27)]
            public bool HeadShot;
            [ProtoMember(0x2a), DefaultValue(120)]
            public float ProjectileHeadShotDamage = 120f;
            [ProtoMember(0x2d), DefaultValue(1)]
            public int ProjectileCount = 1;
        }
    }
}

