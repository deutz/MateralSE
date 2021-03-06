﻿namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyAirVent : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float GetOxygenLevel();
        [Obsolete("IsPressurized() is deprecated, please use CanPressurize instead.")]
        bool IsPressurized();

        bool CanPressurize { get; }

        [Obsolete("IsDepressurizing is deprecated, please use Depressurize instead.")]
        bool IsDepressurizing { get; }

        bool Depressurize { get; set; }

        VentStatus Status { get; }

        bool PressurizationEnabled { get; }
    }
}

