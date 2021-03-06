﻿namespace Sandbox.ModAPI.Ingame
{
    using Sandbox.ModAPI.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyTerminalBlock : IMyCubeBlock, IMyEntity
    {
        void GetActions(List<ITerminalAction> resultList, Func<ITerminalAction, bool> collect = null);
        ITerminalAction GetActionWithName(string name);
        void GetProperties(List<ITerminalProperty> resultList, Func<ITerminalProperty, bool> collect = null);
        ITerminalProperty GetProperty(string id);
        bool HasLocalPlayerAccess();
        bool HasPlayerAccess(long playerId);
        bool IsSameConstructAs(IMyTerminalBlock other);
        void SearchActionsOfName(string name, List<ITerminalAction> resultList, Func<ITerminalAction, bool> collect = null);
        [Obsolete("Use the setter of Customname")]
        void SetCustomName(string text);
        [Obsolete("Use the setter of Customname")]
        void SetCustomName(StringBuilder text);

        string CustomName { get; set; }

        string CustomNameWithFaction { get; }

        string DetailedInfo { get; }

        string CustomInfo { get; }

        string CustomData { get; set; }

        bool ShowOnHUD { get; set; }

        bool ShowInTerminal { get; set; }

        bool ShowInToolbarConfig { get; set; }

        bool ShowInInventory { get; set; }
    }
}

