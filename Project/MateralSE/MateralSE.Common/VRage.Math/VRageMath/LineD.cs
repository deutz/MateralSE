﻿namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LineD
    {
        public Vector3D From;
        public Vector3D To;
        public Vector3D Direction;
        public double Length;
        public LineD(Vector3D from, Vector3D to)
        {
            this.From = from;
            this.To = to;
            this.Direction = to - from;
            this.Length = this.Direction.Normalize();
        }

        public LineD(Vector3D from, Vector3D to, double lineLength)
        {
            this.From = from;
            this.To = to;
            this.Length = lineLength;
            this.Direction = (to - from) / lineLength;
        }

        public static double GetShortestDistanceSquared(LineD line1, LineD line2)
        {
            Vector3D vectord;
            Vector3D vectord2;
            Vector3D vectord1 = GetShortestVector(ref line1, ref line2, out vectord, out vectord2);
            return Vector3D.Dot(vectord1, vectord1);
        }

        public static Vector3D GetShortestVector(ref LineD line1, ref LineD line2, out Vector3D res1, out Vector3D res2)
        {
            double num8;
            double num9;
            double num11;
            double num12;
            double num = 9.9999999747524271E-07;
            Vector3D vectord = new Vector3D {
                X = line1.To.X - line1.From.X,
                Y = line1.To.Y - line1.From.Y,
                Z = line1.To.Z - line1.From.Z
            };
            Vector3D vectord2 = new Vector3D {
                X = line2.To.X - line2.From.X,
                Y = line2.To.Y - line2.From.Y,
                Z = line2.To.Z - line2.From.Z
            };
            Vector3D vectord3 = new Vector3D {
                X = line1.From.X - line2.From.X,
                Y = line1.From.Y - line2.From.Y,
                Z = line1.From.Z - line2.From.Z
            };
            double num2 = Vector3D.Dot(vectord, vectord);
            double num3 = Vector3D.Dot(vectord, vectord2);
            double num4 = Vector3D.Dot(vectord2, vectord2);
            double num5 = Vector3D.Dot(vectord, vectord3);
            double num6 = Vector3D.Dot(vectord2, vectord3);
            if ((num12 = num9 = (num2 * num4) - (num3 * num3)) < num)
            {
                num8 = 0.0;
                num9 = 1.0;
                num11 = num6;
                num12 = num4;
            }
            else
            {
                num8 = (num3 * num6) - (num4 * num5);
                num11 = (num2 * num6) - (num3 * num5);
                if (num8 < 0.0)
                {
                    num8 = 0.0;
                    num11 = num6;
                    num12 = num4;
                }
                else if (num8 > num9)
                {
                    num8 = num9;
                    num11 = num6 + num3;
                    num12 = num4;
                }
            }
            if (num11 < 0.0)
            {
                num11 = 0.0;
                if (-num5 < 0.0)
                {
                    num8 = 0.0;
                }
                else if (-num5 > num2)
                {
                    num8 = num9;
                }
                else
                {
                    num8 = -num5;
                    num9 = num2;
                }
            }
            else if (num11 > num12)
            {
                num11 = num12;
                if ((-num5 + num3) < 0.0)
                {
                    num8 = 0.0;
                }
                else if ((-num5 + num3) > num2)
                {
                    num8 = num9;
                }
                else
                {
                    num8 = -num5 + num3;
                    num9 = num2;
                }
            }
            double num7 = (Math.Abs(num8) >= num) ? (num8 / num9) : 0.0;
            double num10 = (Math.Abs(num11) >= num) ? (num11 / num12) : 0.0;
            res1.X = num7 * vectord.X;
            res1.Y = num7 * vectord.Y;
            res1.Z = num7 * vectord.Z;
            Vector3D vectord4 = new Vector3D {
                X = (vectord3.X - (num10 * vectord2.X)) + res1.X,
                Y = (vectord3.Y - (num10 * vectord2.Y)) + res1.Y,
                Z = (vectord3.Z - (num10 * vectord2.Z)) + res1.Z
            };
            res2 = res1 - vectord4;
            return vectord4;
        }

        public static explicit operator Line(LineD b) => 
            new Line((Vector3) b.From, (Vector3) b.To, true);

        public static explicit operator LineD(Line b) => 
            new LineD(b.From, b.To);

        public BoundingBoxD GetBoundingBox() => 
            new BoundingBoxD(Vector3D.Min(this.From, this.To), Vector3D.Max(this.From, this.To));

        public long GetHash() => 
            (this.From.GetHash() ^ this.To.GetHash());
    }
}

