﻿namespace Sandbox.Game.SessionComponents
{
    using Sandbox.Game.Localization;
    using System;

    [IngameObjective("IngameHelp_FlyingAShipTip", 170)]
    internal class MyIngameHelpFlyingAShipTip : MyIngameHelpObjective
    {
        public MyIngameHelpFlyingAShipTip()
        {
            base.TitleEnum = MySpaceTexts.IngameHelp_FlyingAShip_Title;
            base.RequiredIds = new string[] { "IngameHelp_FlyingAShip" };
            MyIngameHelpDetail detail1 = new MyIngameHelpDetail();
            detail1.TextEnum = MySpaceTexts.IngameHelp_FlyingAShipTip_Detail1;
            MyIngameHelpDetail[] detailArray1 = new MyIngameHelpDetail[2];
            detailArray1[0] = detail1;
            MyIngameHelpDetail detail2 = new MyIngameHelpDetail();
            detail2.TextEnum = MySpaceTexts.IngameHelp_FlyingAShipTip_Detail2;
            detailArray1[1] = detail2;
            base.Details = detailArray1;
            base.DelayToHide = MySessionComponentIngameHelp.DEFAULT_OBJECTIVE_DELAY * 4f;
        }
    }
}
