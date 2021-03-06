﻿namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyEntityForRemoval
    {
        [ProtoMember(0x22)]
        public int TimeLeft;
        [ProtoMember(0x25)]
        public long EntityId;

        public MyEntityForRemoval()
        {
        }

        public MyEntityForRemoval(int time, long id)
        {
            this.TimeLeft = time;
            this.EntityId = id;
        }
    }
}

