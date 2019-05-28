﻿namespace Sandbox.Graphics.GUI.IME
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CompositionForm
    {
        public int dwStyle;
        public POINT_IME ptCurrentPos;
        public RECT_IME rcArea;
    }
}

