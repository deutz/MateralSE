﻿namespace VRage.Noise.Combiners
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.Noise;

    public class MyMultiply : IMyModule
    {
        public MyMultiply(IMyModule sourceModule1, IMyModule sourceModule2)
        {
            this.Source1 = sourceModule1;
            this.Source2 = sourceModule2;
        }

        public double GetValue(double x) => 
            (this.Source1.GetValue(x) * this.Source2.GetValue(x));

        public double GetValue(double x, double y) => 
            (this.Source1.GetValue(x, y) * this.Source2.GetValue(x, y));

        public double GetValue(double x, double y, double z) => 
            (this.Source1.GetValue(x, y, z) * this.Source2.GetValue(x, y, z));

        public IMyModule Source1 { get; set; }

        public IMyModule Source2 { get; set; }
    }
}

