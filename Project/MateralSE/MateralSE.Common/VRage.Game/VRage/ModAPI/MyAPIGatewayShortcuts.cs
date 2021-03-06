﻿namespace VRage.ModAPI
{
    using System;
    using System.Runtime.CompilerServices;
    using VRageMath;

    public static class MyAPIGatewayShortcuts
    {
        public static Action<IMyEntity> RegisterEntityUpdate;
        public static Action<IMyEntity, bool> UnregisterEntityUpdate;
        public static GetMainCameraCallback GetMainCamera;
        public static GetWorldBoundariesCallback GetWorldBoundaries;
        public static GetLocalPlayerPositionCallback GetLocalPlayerPosition;

        public delegate Vector3D GetLocalPlayerPositionCallback();

        public delegate IMyCamera GetMainCameraCallback();

        public delegate BoundingBoxD GetWorldBoundariesCallback();
    }
}

