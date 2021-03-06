﻿namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Unsharper;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract, UnsharperDisableReflection]
    public struct Vector3 : IEquatable<Vector3>
    {
        public static Vector3 Zero;
        public static Vector3 One;
        public static Vector3 MinusOne;
        public static Vector3 Half;
        public static Vector3 PositiveInfinity;
        public static Vector3 NegativeInfinity;
        public static Vector3 UnitX;
        public static Vector3 UnitY;
        public static Vector3 UnitZ;
        public static Vector3 Up;
        public static Vector3 Down;
        public static Vector3 Right;
        public static Vector3 Left;
        public static Vector3 Forward;
        public static Vector3 Backward;
        public static Vector3 MaxValue;
        public static Vector3 MinValue;
        public static Vector3 Invalid;
        [ProtoMember(40)]
        public float X;
        [ProtoMember(0x2d)]
        public float Y;
        [ProtoMember(50)]
        public float Z;
        static Vector3()
        {
            Zero = new Vector3();
            One = new Vector3(1f, 1f, 1f);
            MinusOne = new Vector3(-1f, -1f, -1f);
            Half = new Vector3(0.5f, 0.5f, 0.5f);
            PositiveInfinity = new Vector3(float.PositiveInfinity);
            NegativeInfinity = new Vector3(float.NegativeInfinity);
            UnitX = new Vector3(1f, 0f, 0f);
            UnitY = new Vector3(0f, 1f, 0f);
            UnitZ = new Vector3(0f, 0f, 1f);
            Up = new Vector3(0f, 1f, 0f);
            Down = new Vector3(0f, -1f, 0f);
            Right = new Vector3(1f, 0f, 0f);
            Left = new Vector3(-1f, 0f, 0f);
            Forward = new Vector3(0f, 0f, -1f);
            Backward = new Vector3(0f, 0f, 1f);
            MaxValue = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            MinValue = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            Invalid = new Vector3(float.NaN);
        }

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3(double x, double y, double z)
        {
            this.X = (float) x;
            this.Y = (float) y;
            this.Z = (float) z;
        }

        public Vector3(float value)
        {
            float num;
            this.Z = num = value;
            this.X = this.Y = num;
        }

        public Vector3(Vector2 value, float z)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
        }

        public Vector3(Vector4 xyz)
        {
            this.X = xyz.X;
            this.Y = xyz.Y;
            this.Z = xyz.Z;
        }

        public Vector3(ref Vector3I value)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
        }

        public Vector3(Vector3I value)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
        }

        public static Vector3 operator -(Vector3 value)
        {
            Vector3 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            vector.Z = -value.Z;
            return vector;
        }

        public static bool operator ==(Vector3 value1, Vector3 value2) => 
            ((value1.X == value2.X) && ((value1.Y == value2.Y) && (value1.Z == value2.Z)));

        public static bool operator !=(Vector3 value1, Vector3 value2) => 
            ((value1.X != value2.X) || ((value1.Y != value2.Y) || !(value1.Z == value2.Z)));

        public static Vector3 operator +(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X + value2.X;
            vector.Y = value1.Y + value2.Y;
            vector.Z = value1.Z + value2.Z;
            return vector;
        }

        public static Vector3 operator +(Vector3 value1, float value2)
        {
            Vector3 vector;
            vector.X = value1.X + value2;
            vector.Y = value1.Y + value2;
            vector.Z = value1.Z + value2;
            return vector;
        }

        public static Vector3 operator -(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X - value2.X;
            vector.Y = value1.Y - value2.Y;
            vector.Z = value1.Z - value2.Z;
            return vector;
        }

        public static Vector3 operator -(Vector3 value1, float value2)
        {
            Vector3 vector;
            vector.X = value1.X - value2;
            vector.Y = value1.Y - value2;
            vector.Z = value1.Z - value2;
            return vector;
        }

        public static Vector3 operator *(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X * value2.X;
            vector.Y = value1.Y * value2.Y;
            vector.Z = value1.Z * value2.Z;
            return vector;
        }

        public static Vector3 operator *(Vector3 value, float scaleFactor)
        {
            Vector3 vector;
            vector.X = value.X * scaleFactor;
            vector.Y = value.Y * scaleFactor;
            vector.Z = value.Z * scaleFactor;
            return vector;
        }

        public static Vector3 operator *(float scaleFactor, Vector3 value)
        {
            Vector3 vector;
            vector.X = value.X * scaleFactor;
            vector.Y = value.Y * scaleFactor;
            vector.Z = value.Z * scaleFactor;
            return vector;
        }

        public static Vector3 operator /(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X / value2.X;
            vector.Y = value1.Y / value2.Y;
            vector.Z = value1.Z / value2.Z;
            return vector;
        }

        public static Vector3 operator /(Vector3 value, float divider)
        {
            Vector3 vector;
            float num = 1f / divider;
            vector.X = value.X * num;
            vector.Y = value.Y * num;
            vector.Z = value.Z * num;
            return vector;
        }

        public static Vector3 operator /(float value, Vector3 divider)
        {
            Vector3 vector;
            vector.X = value / divider.X;
            vector.Y = value / divider.Y;
            vector.Z = value / divider.Z;
            return vector;
        }

        public void Divide(float divider)
        {
            float num = 1f / divider;
            this.X *= num;
            this.Y *= num;
            this.Z *= num;
        }

        public void Multiply(float scale)
        {
            this.X *= scale;
            this.Y *= scale;
            this.Z *= scale;
        }

        public void Add(Vector3 other)
        {
            this.X += other.X;
            this.Y += other.Y;
            this.Z += other.Z;
        }

        public static Vector3 Abs(Vector3 value) => 
            new Vector3(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));

        public static Vector3 Sign(Vector3 value) => 
            new Vector3((float) Math.Sign(value.X), (float) Math.Sign(value.Y), (float) Math.Sign(value.Z));

        private static float Sign(float v, float epsilon) => 
            ((v > epsilon) ? 1f : ((v < -epsilon) ? -1f : 0f));

        public static Vector3 Sign(Vector3 value, float epsilon) => 
            new Vector3(Sign(value.X, epsilon), Sign(value.Y, epsilon), Sign(value.Z, epsilon));

        public static Vector3 SignNonZero(Vector3 value) => 
            new Vector3((value.X < 0f) ? ((float) (-1)) : ((float) 1), (value.Y < 0f) ? ((float) (-1)) : ((float) 1), (value.Z < 0f) ? ((float) (-1)) : ((float) 1));

        public void Interpolate3(Vector3 v0, Vector3 v1, float rt)
        {
            float num = 1f - rt;
            this.X = (num * v0.X) + (rt * v1.X);
            this.Y = (num * v0.Y) + (rt * v1.Y);
            this.Z = (num * v0.Z) + (rt * v1.Z);
        }

        public bool IsValid() => 
            ((this.X * this.Y) * this.Z).IsValid();

        [Conditional("DEBUG")]
        public void AssertIsValid()
        {
        }

        public static bool IsUnit(ref Vector3 value)
        {
            float num = value.LengthSquared();
            return ((num >= 0.9999f) && (num < 1.0001f));
        }

        public static bool ArePerpendicular(ref Vector3 a, ref Vector3 b)
        {
            float single1 = a.Dot((Vector3) b);
            return ((single1 * single1) < ((1E-08f * a.LengthSquared()) * b.LengthSquared()));
        }

        public static bool IsZero(Vector3 value) => 
            IsZero(value, 0.0001f);

        public static bool IsZero(Vector3 value, float epsilon) => 
            ((Math.Abs(value.X) < epsilon) && ((Math.Abs(value.Y) < epsilon) && (Math.Abs(value.Z) < epsilon)));

        public static Vector3 IsZeroVector(Vector3 value) => 
            new Vector3((value.X == 0f) ? ((float) 1) : ((float) 0), (value.Y == 0f) ? ((float) 1) : ((float) 0), (value.Z == 0f) ? ((float) 1) : ((float) 0));

        public static Vector3 IsZeroVector(Vector3 value, float epsilon) => 
            new Vector3((Math.Abs(value.X) < epsilon) ? ((float) 1) : ((float) 0), (Math.Abs(value.Y) < epsilon) ? ((float) 1) : ((float) 0), (Math.Abs(value.Z) < epsilon) ? ((float) 1) : ((float) 0));

        public static Vector3 Step(Vector3 value) => 
            new Vector3((value.X > 0f) ? ((float) 1) : ((value.X < 0f) ? ((float) (-1)) : ((float) 0)), (value.Y > 0f) ? ((float) 1) : ((value.Y < 0f) ? ((float) (-1)) : ((float) 0)), (value.Z > 0f) ? ((float) 1) : ((value.Z < 0f) ? ((float) (-1)) : ((float) 0)));

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2}}}", this.X.ToString(currentCulture), this.Y.ToString(currentCulture), this.Z.ToString(currentCulture));
        }

        public string ToString(string format)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2}}}", this.X.ToString(format, currentCulture), this.Y.ToString(format, currentCulture), this.Z.ToString(format, currentCulture));
        }

        public bool Equals(Vector3 other) => 
            ((this.X == other.X) && ((this.Y == other.Y) && (this.Z == other.Z)));

        public bool Equals(Vector3 other, float epsilon) => 
            ((Math.Abs((float) (this.X - other.X)) < epsilon) && ((Math.Abs((float) (this.Y - other.Y)) < epsilon) && (Math.Abs((float) (this.Z - other.Z)) < epsilon)));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector3)
            {
                flag = this.Equals((Vector3) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            ((((((int) (this.X * 997f)) * 0x18d) ^ ((int) (this.Y * 997f))) * 0x18d) ^ ((int) (this.Z * 997f)));

        public long GetHash()
        {
            int num = 0;
            num = 2;
            num += 4;
            num += 0x10;
            num += 0x100;
            num += 0x10000;
            num++;
            return ((((((((((((((long) Math.Round((double) Math.Abs((float) (this.X * 1000f)))) * 0x18dL) ^ ((long) Math.Round((double) Math.Abs((float) (this.Y * 1000f))))) * 0x18dL) ^ ((long) Math.Round((double) Math.Abs((float) (this.Z * 1000f))))) * 0x18dL) ^ (Math.Sign(this.X) + 5)) * 0x18dL) ^ (Math.Sign(this.Y) + 7)) * 0x18dL) ^ (Math.Sign(this.Z) + 11)) * 0x18dL) ^ num);
        }

        public float Length() => 
            ((float) Math.Sqrt((double) (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z))));

        public float LengthSquared() => 
            (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z));

        public static float Distance(Vector3 value1, Vector3 value2)
        {
            float num = value1.Y - value2.Y;
            float num2 = value1.Z - value2.Z;
            float single1 = value1.X - value2.X;
            return (float) Math.Sqrt((double) (((single1 * single1) + (num * num)) + (num2 * num2)));
        }

        public static void Distance(ref Vector3 value1, ref Vector3 value2, out float result)
        {
            float num = value1.Y - value2.Y;
            float num2 = value1.Z - value2.Z;
            float single1 = value1.X - value2.X;
            float num3 = ((single1 * single1) + (num * num)) + (num2 * num2);
            result = (float) Math.Sqrt((double) num3);
        }

        public static float DistanceSquared(Vector3 value1, Vector3 value2)
        {
            float num = value1.Y - value2.Y;
            float num2 = value1.Z - value2.Z;
            float single1 = value1.X - value2.X;
            return (((single1 * single1) + (num * num)) + (num2 * num2));
        }

        public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out float result)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            result = ((num * num) + (num2 * num2)) + (num3 * num3);
        }

        public static float RectangularDistance(Vector3 value1, Vector3 value2)
        {
            Vector3 vector = Abs(value1 - value2);
            return ((vector.X + vector.Y) + vector.Z);
        }

        public static float RectangularDistance(ref Vector3 value1, ref Vector3 value2)
        {
            Vector3 vector = Abs(value1 - value2);
            return ((vector.X + vector.Y) + vector.Z);
        }

        public static float Dot(Vector3 vector1, Vector3 vector2) => 
            (((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z));

        public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out float result)
        {
            result = ((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z);
        }

        public float Dot(Vector3 v) => 
            this.Dot(ref v);

        public float Dot(ref Vector3 v) => 
            (((this.X * v.X) + (this.Y * v.Y)) + (this.Z * v.Z));

        public Vector3 Cross(Vector3 v) => 
            Cross(this, v);

        public float Normalize()
        {
            float num = (float) Math.Sqrt((double) (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)));
            float num2 = 1f / num;
            this.X *= num2;
            this.Y *= num2;
            this.Z *= num2;
            return num;
        }

        public static Vector3 Normalize(Vector3 value)
        {
            Vector3 vector;
            float num = 1f / ((float) Math.Sqrt((double) (((value.X * value.X) + (value.Y * value.Y)) + (value.Z * value.Z))));
            vector.X = value.X * num;
            vector.Y = value.Y * num;
            vector.Z = value.Z * num;
            return vector;
        }

        public static Vector3 Normalize(Vector3D value)
        {
            Vector3 vector;
            float num = 1f / ((float) Math.Sqrt(((value.X * value.X) + (value.Y * value.Y)) + (value.Z * value.Z)));
            vector.X = ((float) value.X) * num;
            vector.Y = ((float) value.Y) * num;
            vector.Z = ((float) value.Z) * num;
            return vector;
        }

        public static bool GetNormalized(ref Vector3 value)
        {
            Vector3 vector;
            float num = (float) Math.Sqrt((double) (((value.X * value.X) + (value.Y * value.Y)) + (value.Z * value.Z)));
            if (num <= 0.001f)
            {
                return false;
            }
            float num2 = 1f / num;
            vector.X = value.X * num2;
            vector.Y = value.Y * num2;
            vector.Z = value.Z * num2;
            return true;
        }

        public static void Normalize(ref Vector3 value, out Vector3 result)
        {
            float num = 1f / ((float) Math.Sqrt((double) (((value.X * value.X) + (value.Y * value.Y)) + (value.Z * value.Z))));
            result.X = value.X * num;
            result.Y = value.Y * num;
            result.Z = value.Z * num;
        }

        public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
        {
            Vector3 vector;
            vector.X = (vector1.Y * vector2.Z) - (vector1.Z * vector2.Y);
            vector.Y = (vector1.Z * vector2.X) - (vector1.X * vector2.Z);
            vector.Z = (vector1.X * vector2.Y) - (vector1.Y * vector2.X);
            return vector;
        }

        public static void Cross(ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
        {
            float num = (vector1.Y * vector2.Z) - (vector1.Z * vector2.Y);
            float num2 = (vector1.Z * vector2.X) - (vector1.X * vector2.Z);
            float num3 = (vector1.X * vector2.Y) - (vector1.Y * vector2.X);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            Vector3 vector2;
            float num = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            vector2.X = vector.X - ((2f * num) * normal.X);
            vector2.Y = vector.Y - ((2f * num) * normal.Y);
            vector2.Z = vector.Z - ((2f * num) * normal.Z);
            return vector2;
        }

        public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
        {
            float num = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            result.X = vector.X - ((2f * num) * normal.X);
            result.Y = vector.Y - ((2f * num) * normal.Y);
            result.Z = vector.Z - ((2f * num) * normal.Z);
        }

        public static Vector3 Reject(Vector3 vector, Vector3 direction)
        {
            Vector3 vector2;
            Reject(ref vector, ref direction, out vector2);
            return vector2;
        }

        public static void Reject(ref Vector3 vector, ref Vector3 direction, out Vector3 result)
        {
            float num;
            float num2;
            Vector3 vector2;
            Dot(ref direction, ref direction, out num);
            num = 1f / num;
            Dot(ref direction, ref vector, out num2);
            num2 *= num;
            vector2.X = direction.X * num;
            vector2.Y = direction.Y * num;
            vector2.Z = direction.Z * num;
            result.X = vector.X - (num2 * vector2.X);
            result.Y = vector.Y - (num2 * vector2.Y);
            result.Z = vector.Z - (num2 * vector2.Z);
        }

        public float Min() => 
            ((this.X >= this.Y) ? ((this.Y >= this.Z) ? this.Z : this.Y) : ((this.X >= this.Z) ? this.Z : this.X));

        public float AbsMin() => 
            ((Math.Abs(this.X) >= Math.Abs(this.Y)) ? ((Math.Abs(this.Y) >= Math.Abs(this.Z)) ? Math.Abs(this.Z) : Math.Abs(this.Y)) : ((Math.Abs(this.X) >= Math.Abs(this.Z)) ? Math.Abs(this.Z) : Math.Abs(this.X)));

        public float Max() => 
            ((this.X <= this.Y) ? ((this.Y <= this.Z) ? this.Z : this.Y) : ((this.X <= this.Z) ? this.Z : this.X));

        public Vector3 MaxAbsComponent()
        {
            Vector3 vector = this;
            Vector3 vector2 = Abs(vector);
            float num = vector2.Max();
            if (vector2.X != num)
            {
                vector.X = 0f;
            }
            if (vector2.Y != num)
            {
                vector.Y = 0f;
            }
            if (vector2.Z != num)
            {
                vector.Z = 0f;
            }
            return vector;
        }

        public float AbsMax() => 
            ((Math.Abs(this.X) <= Math.Abs(this.Y)) ? ((Math.Abs(this.Y) <= Math.Abs(this.Z)) ? Math.Abs(this.Z) : Math.Abs(this.Y)) : ((Math.Abs(this.X) <= Math.Abs(this.Z)) ? Math.Abs(this.Z) : Math.Abs(this.X)));

        public static unsafe Vector3 Min(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            Vector3* vectorPtr1;
            Vector3* vectorPtr2;
            Vector3* vectorPtr3;
            vectorPtr1->X = (value1.X < value2.X) ? value1.X : value2.X;
            vectorPtr1 = (Vector3*) ref vector;
            vectorPtr2->Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            vectorPtr2 = (Vector3*) ref vector;
            vectorPtr3->Z = (value1.Z < value2.Z) ? value1.Z : value2.Z;
            vectorPtr3 = (Vector3*) ref vector;
            return vector;
        }

        public static void Min(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = (value1.X < value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z < value2.Z) ? value1.Z : value2.Z;
        }

        public static unsafe Vector3 Max(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            Vector3* vectorPtr1;
            Vector3* vectorPtr2;
            Vector3* vectorPtr3;
            vectorPtr1->X = (value1.X > value2.X) ? value1.X : value2.X;
            vectorPtr1 = (Vector3*) ref vector;
            vectorPtr2->Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            vectorPtr2 = (Vector3*) ref vector;
            vectorPtr3->Z = (value1.Z > value2.Z) ? value1.Z : value2.Z;
            vectorPtr3 = (Vector3*) ref vector;
            return vector;
        }

        public static void Max(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = (value1.X > value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z > value2.Z) ? value1.Z : value2.Z;
        }

        public static void MinMax(ref Vector3 min, ref Vector3 max)
        {
            float x;
            if (min.X > max.X)
            {
                x = min.X;
                min.X = max.X;
                max.X = x;
            }
            if (min.Y > max.Y)
            {
                x = min.Y;
                min.Y = max.Y;
                max.Y = x;
            }
            if (min.Z > max.Z)
            {
                x = min.Z;
                min.Z = max.Z;
                max.Z = x;
            }
        }

        public static Vector3 DominantAxisProjection(Vector3 value1)
        {
            Vector3 vector;
            DominantAxisProjection(ref value1, out vector);
            return vector;
        }

        public static void DominantAxisProjection(ref Vector3 value1, out Vector3 result)
        {
            if (Math.Abs(value1.X) > Math.Abs(value1.Y))
            {
                result = (Math.Abs(value1.X) > Math.Abs(value1.Z)) ? new Vector3(value1.X, 0f, 0f) : new Vector3(0f, 0f, value1.Z);
            }
            else
            {
                result = (Math.Abs(value1.Y) > Math.Abs(value1.Z)) ? new Vector3(0f, value1.Y, 0f) : new Vector3(0f, 0f, value1.Z);
            }
        }

        public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max)
        {
            Vector3 vector = value1;
            if (value1.X > max.X)
            {
                vector.X = max.X;
            }
            else if (value1.X < min.X)
            {
                vector.X = min.X;
            }
            if (value1.Y > max.Y)
            {
                vector.Y = max.Y;
            }
            else if (value1.Y < min.Y)
            {
                vector.Y = min.Y;
            }
            if (value1.Z > max.Z)
            {
                vector.Z = max.Z;
            }
            else if (value1.Z < min.Z)
            {
                vector.Z = min.Z;
            }
            return vector;
        }

        public static void Clamp(ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
        {
            result = value1;
            if (value1.X > max.X)
            {
                result.X = max.X;
            }
            else if (value1.X < min.X)
            {
                result.X = min.X;
            }
            if (value1.Y > max.Y)
            {
                result.Y = max.Y;
            }
            else if (value1.Y < min.Y)
            {
                result.Y = min.Y;
            }
            if (value1.Z > max.Z)
            {
                result.Z = max.Z;
            }
            else if (value1.Z < min.Z)
            {
                result.Z = min.Z;
            }
        }

        public static Vector3 ClampToSphere(Vector3 vector, float radius)
        {
            float num = vector.LengthSquared();
            float num2 = radius * radius;
            return ((num <= num2) ? vector : (vector * ((float) Math.Sqrt((double) (num2 / num)))));
        }

        public static void ClampToSphere(ref Vector3 vector, float radius)
        {
            float num = vector.LengthSquared();
            float num2 = radius * radius;
            if (num > num2)
            {
                vector *= (float) Math.Sqrt((double) (num2 / num));
            }
        }

        public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
        {
            Vector3 vector;
            vector.X = value1.X + ((value2.X - value1.X) * amount);
            vector.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vector.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            return vector;
        }

        public static void Lerp(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
        {
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
        }

        public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
        {
            Vector3 vector;
            vector.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            vector.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            vector.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
            return vector;
        }

        public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float amount1, float amount2, out Vector3 result)
        {
            result.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            result.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            result.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
        }

        public static void Barycentric(Vector3 p, Vector3 a, Vector3 b, Vector3 c, out float u, out float v, out float w)
        {
            Vector3 vector = b - a;
            Vector3 vector2 = c - a;
            float num = Dot(vector, vector);
            float num2 = Dot(vector, vector2);
            float num3 = Dot(vector2, vector2);
            Vector3 vector1 = p - a;
            float num4 = Dot(vector1, vector);
            float num5 = Dot(vector1, vector2);
            float num6 = (num * num3) - (num2 * num2);
            v = ((num3 * num4) - (num2 * num5)) / num6;
            w = ((num * num5) - (num2 * num4)) / num6;
            u = (1f - v) - w;
        }

        public static float TriangleArea(Vector3 v1, Vector3 v2, Vector3 v3) => 
            (Cross(v2 - v1, v3 - v1).Length() * 0.5f);

        public static float TriangleArea(ref Vector3 v1, ref Vector3 v2, ref Vector3 v3)
        {
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3;
            Subtract(ref v2, ref v1, out vector2);
            Subtract(ref v3, ref v1, out vector3);
            Cross(ref vector2, ref vector3, out vector);
            return (vector.Length() * 0.5f);
        }

        public static Vector3 SmoothStep(Vector3 value1, Vector3 value2, float amount)
        {
            Vector3 vector;
            float single1 = amount;
            amount = (amount > 1.0) ? 1f : ((amount < 0.0) ? 0f : single1);
            amount = (float) ((amount * amount) * (3.0 - (2.0 * amount)));
            vector.X = value1.X + ((value2.X - value1.X) * amount);
            vector.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vector.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            return vector;
        }

        public static void SmoothStep(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
        {
            float single1 = amount;
            amount = (amount > 1.0) ? 1f : ((amount < 0.0) ? 0f : single1);
            amount = (float) ((amount * amount) * (3.0 - (2.0 * amount)));
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
        }

        public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
        {
            Vector3 vector;
            float num = amount * amount;
            float num2 = amount * num;
            vector.X = (float) (0.5 * ((((2.0 * value2.X) + ((-((double) value1.X) + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-((double) value1.X) + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2)));
            vector.Y = (float) (0.5 * ((((2.0 * value2.Y) + ((-((double) value1.Y) + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-((double) value1.Y) + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2)));
            vector.Z = (float) (0.5 * ((((2.0 * value2.Z) + ((-((double) value1.Z) + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-((double) value1.Z) + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2)));
            return vector;
        }

        public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float amount, out Vector3 result)
        {
            float num = amount * amount;
            float num2 = amount * num;
            result.X = (float) (0.5 * ((((2.0 * value2.X) + ((-((double) value1.X) + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-((double) value1.X) + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2)));
            result.Y = (float) (0.5 * ((((2.0 * value2.Y) + ((-((double) value1.Y) + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-((double) value1.Y) + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2)));
            result.Z = (float) (0.5 * ((((2.0 * value2.Z) + ((-((double) value1.Z) + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-((double) value1.Z) + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2)));
        }

        public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
        {
            Vector3 vector;
            float num = amount * amount;
            float num2 = amount * num;
            float num3 = (float) (((2.0 * num2) - (3.0 * num)) + 1.0);
            float num4 = (float) ((-2.0 * num2) + (3.0 * num));
            float num5 = (num2 - (2f * num)) + amount;
            float num6 = num2 - num;
            vector.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            vector.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            vector.Z = (((value1.Z * num3) + (value2.Z * num4)) + (tangent1.Z * num5)) + (tangent2.Z * num6);
            return vector;
        }

        public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
        {
            float num = amount * amount;
            float num2 = amount * num;
            float num3 = (float) (((2.0 * num2) - (3.0 * num)) + 1.0);
            float num4 = (float) ((-2.0 * num2) + (3.0 * num));
            float num5 = (num2 - (2f * num)) + amount;
            float num6 = num2 - num;
            result.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            result.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            result.Z = (((value1.Z * num3) + (value2.Z * num4)) + (tangent1.Z * num5)) + (tangent2.Z * num6);
        }

        public static Vector3 Transform(Vector3 position, Matrix matrix)
        {
            Vector3 vector;
            float num4 = 1f / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            vector.X = ((((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41) * num4;
            vector.Y = ((((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42) * num4;
            vector.Z = ((((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43) * num4;
            return vector;
        }

        public static Vector3D Transform(Vector3 position, MatrixD matrix)
        {
            Vector3D vectord;
            double num4 = 1.0 / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            vectord.X = ((((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41) * num4;
            vectord.Y = ((((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42) * num4;
            vectord.Z = ((((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43) * num4;
            return vectord;
        }

        public static Vector3 Transform(Vector3 position, ref Matrix matrix)
        {
            Transform(ref position, ref matrix, out position);
            return position;
        }

        public static void Transform(ref Vector3 position, ref Matrix matrix, out Vector3 result)
        {
            float num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            float num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            float num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            float num4 = 1f / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            result.X = num * num4;
            result.Y = num2 * num4;
            result.Z = num3 * num4;
        }

        public static void Transform(ref Vector3 position, ref MatrixI matrix, out Vector3 result)
        {
            result = (Vector3) ((((position.X * Base6Directions.GetVector(matrix.Right)) + (position.Y * Base6Directions.GetVector(matrix.Up))) + (position.Z * Base6Directions.GetVector(matrix.Backward))) + matrix.Translation);
        }

        public static void TransformProjection(ref Vector3 position, ref Matrix matrix, out Vector3 result)
        {
            float num = position.X * matrix.M11;
            float num2 = position.Y * matrix.M22;
            float num3 = (position.Z * matrix.M33) + matrix.M43;
            float num4 = 1f / ((position.Z * matrix.M34) + matrix.M44);
            result.X = num * num4;
            result.Y = num2 * num4;
            result.Z = num3 * num4;
        }

        public static void TransformNoProjection(ref Vector3 vector, ref Matrix matrix, out Vector3 result)
        {
            float num = (((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31)) + matrix.M41;
            float num2 = (((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32)) + matrix.M42;
            float num3 = (((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33)) + matrix.M43;
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static void RotateAndScale(ref Vector3 vector, ref Matrix matrix, out Vector3 result)
        {
            float num = ((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31);
            float num2 = ((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32);
            float num3 = ((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static Vector3 RotateAndScale(Vector3 vector, Matrix matrix)
        {
            Vector3 vector2;
            RotateAndScale(ref vector, ref matrix, out vector2);
            return vector2;
        }

        public static Vector3 TransformNormal(Vector3 normal, Matrix matrix)
        {
            Vector3 vector;
            vector.X = ((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31);
            vector.Y = ((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32);
            vector.Z = ((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33);
            return vector;
        }

        public static Vector3 TransformNormal(Vector3 normal, MatrixD matrix)
        {
            Vector3 vector;
            vector.X = (float) (((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31));
            vector.Y = (float) (((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32));
            vector.Z = (float) (((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33));
            return vector;
        }

        public static Vector3 TransformNormal(Vector3D normal, Matrix matrix)
        {
            Vector3 vector;
            vector.X = (float) (((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31));
            vector.Y = (float) (((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32));
            vector.Z = (float) (((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33));
            return vector;
        }

        public static void TransformNormal(ref Vector3 normal, ref Matrix matrix, out Vector3 result)
        {
            float num = ((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31);
            float num2 = ((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32);
            float num3 = ((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static void TransformNormal(ref Vector3 normal, ref MatrixD matrix, out Vector3 result)
        {
            float num = (float) (((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31));
            float num2 = (float) (((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32));
            float num3 = (float) (((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33));
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static void TransformNormal(ref Vector3 normal, ref MatrixI matrix, out Vector3 result)
        {
            result = (Vector3) (((normal.X * Base6Directions.GetVector(matrix.Right)) + (normal.Y * Base6Directions.GetVector(matrix.Up))) + (normal.Z * Base6Directions.GetVector(matrix.Backward)));
        }

        public static Vector3 TransformNormal(Vector3 normal, MyBlockOrientation orientation)
        {
            Vector3 vector;
            TransformNormal(ref normal, orientation, out vector);
            return vector;
        }

        public static void TransformNormal(ref Vector3 normal, MyBlockOrientation orientation, out Vector3 result)
        {
            result = (Vector3) (((-normal.X * Base6Directions.GetVector(orientation.Left)) + (normal.Y * Base6Directions.GetVector(orientation.Up))) - (normal.Z * Base6Directions.GetVector(orientation.Forward)));
        }

        public static Vector3 TransformNormal(Vector3 normal, ref Matrix matrix)
        {
            TransformNormal(ref normal, ref matrix, out normal);
            return normal;
        }

        public static Vector3 Transform(Vector3 value, Quaternion rotation)
        {
            Vector3 vector;
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            vector.X = (((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            vector.Y = ((value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)))) + (value.Z * (num11 - num4));
            vector.Z = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + ((float) (value.Z * ((1.0 - num7) - num10)));
            return vector;
        }

        public static void Transform(ref Vector3 value, ref Quaternion rotation, out Vector3 result)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = (((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            float num14 = ((value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)))) + (value.Z * (num11 - num4));
            float num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + ((float) (value.Z * ((1.0 - num7) - num10)));
            result.X = num13;
            result.Y = num14;
            result.Z = num15;
        }

        public static void Transform(Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                float z = sourceArray[i].Z;
                destinationArray[i].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + matrix.M41;
                destinationArray[i].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + matrix.M42;
                destinationArray[i].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + matrix.M43;
            }
        }

        public static void Transform(Vector3[] sourceArray, int sourceIndex, ref Matrix matrix, Vector3[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                float z = sourceArray[sourceIndex].Z;
                destinationArray[destinationIndex].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + matrix.M41;
                destinationArray[destinationIndex].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + matrix.M42;
                destinationArray[destinationIndex].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + matrix.M43;
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void TransformNormal(Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                float z = sourceArray[i].Z;
                destinationArray[i].X = ((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31);
                destinationArray[i].Y = ((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32);
                destinationArray[i].Z = ((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33);
            }
        }

        public static void TransformNormal(Vector3[] sourceArray, int sourceIndex, ref Matrix matrix, Vector3[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                float z = sourceArray[sourceIndex].Z;
                destinationArray[destinationIndex].X = ((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31);
                destinationArray[destinationIndex].Y = ((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32);
                destinationArray[destinationIndex].Z = ((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void Transform(Vector3[] sourceArray, ref Quaternion rotation, Vector3[] destinationArray)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num3;
            float num9 = rotation.Y * num2;
            float num10 = rotation.Y * num3;
            float num11 = rotation.Z * num3;
            float num12 = (1f - num9) - num11;
            float single1 = rotation.X * num2;
            float num13 = single1 - num6;
            float num14 = num8 + num5;
            float num15 = single1 + num6;
            float num16 = (1f - num7) - num11;
            float num17 = num10 - num4;
            float num18 = num8 - num5;
            float num19 = num10 + num4;
            float num20 = (1f - num7) - num9;
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                float z = sourceArray[i].Z;
                destinationArray[i].X = ((x * num12) + (y * num13)) + (z * num14);
                destinationArray[i].Y = ((x * num15) + (y * num16)) + (z * num17);
                destinationArray[i].Z = ((x * num18) + (y * num19)) + (z * num20);
            }
        }

        public static void Transform(Vector3[] sourceArray, int sourceIndex, ref Quaternion rotation, Vector3[] destinationArray, int destinationIndex, int length)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num3;
            float num9 = rotation.Y * num2;
            float num10 = rotation.Y * num3;
            float num11 = rotation.Z * num3;
            float num12 = (1f - num9) - num11;
            float single1 = rotation.X * num2;
            float num13 = single1 - num6;
            float num14 = num8 + num5;
            float num15 = single1 + num6;
            float num16 = (1f - num7) - num11;
            float num17 = num10 - num4;
            float num18 = num8 - num5;
            float num19 = num10 + num4;
            float num20 = (1f - num7) - num9;
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                float z = sourceArray[sourceIndex].Z;
                destinationArray[destinationIndex].X = ((x * num12) + (y * num13)) + (z * num14);
                destinationArray[destinationIndex].Y = ((x * num15) + (y * num16)) + (z * num17);
                destinationArray[destinationIndex].Z = ((x * num18) + (y * num19)) + (z * num20);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static Vector3 Negate(Vector3 value)
        {
            Vector3 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            vector.Z = -value.Z;
            return vector;
        }

        public static void Negate(ref Vector3 value, out Vector3 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
        }

        public static Vector3 Add(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X + value2.X;
            vector.Y = value1.Y + value2.Y;
            vector.Z = value1.Z + value2.Z;
            return vector;
        }

        public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        public static Vector3 Subtract(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X - value2.X;
            vector.Y = value1.Y - value2.Y;
            vector.Z = value1.Z - value2.Z;
            return vector;
        }

        public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        public static Vector3 Multiply(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X * value2.X;
            vector.Y = value1.Y * value2.Y;
            vector.Z = value1.Z * value2.Z;
            return vector;
        }

        public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        public static Vector3 Multiply(Vector3 value1, float scaleFactor)
        {
            Vector3 vector;
            vector.X = value1.X * scaleFactor;
            vector.Y = value1.Y * scaleFactor;
            vector.Z = value1.Z * scaleFactor;
            return vector;
        }

        public static void Multiply(ref Vector3 value1, float scaleFactor, out Vector3 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        public static Vector3 Divide(Vector3 value1, Vector3 value2)
        {
            Vector3 vector;
            vector.X = value1.X / value2.X;
            vector.Y = value1.Y / value2.Y;
            vector.Z = value1.Z / value2.Z;
            return vector;
        }

        public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        public static Vector3 Divide(Vector3 value1, float value2)
        {
            Vector3 vector;
            float num = 1f / value2;
            vector.X = value1.X * num;
            vector.Y = value1.Y * num;
            vector.Z = value1.Z * num;
            return vector;
        }

        public static void Divide(ref Vector3 value1, float value2, out Vector3 result)
        {
            float num = 1f / value2;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
            result.Z = value1.Z * num;
        }

        public static Vector3 CalculatePerpendicularVector(Vector3 v)
        {
            Vector3 vector;
            v.CalculatePerpendicularVector(out vector);
            return vector;
        }

        public void CalculatePerpendicularVector(out Vector3 result)
        {
            if ((Math.Abs((float) (this.Y + this.Z)) > 0.0001f) || (Math.Abs(this.X) > 0.0001f))
            {
                result = new Vector3(-(this.Y + this.Z), this.X, this.X);
            }
            else
            {
                result = new Vector3(this.Z, this.Z, -(this.X + this.Y));
            }
            Normalize(ref result, out result);
        }

        public static void GetAzimuthAndElevation(Vector3 v, out float azimuth, out float elevation)
        {
            float num;
            float num2;
            Dot(ref v, ref Up, out num);
            v.Y = 0f;
            v.Normalize();
            Dot(ref v, ref Forward, out num2);
            elevation = (float) Math.Asin((double) num);
            if (v.X >= 0f)
            {
                azimuth = -((float) Math.Acos((double) num2));
            }
            else
            {
                azimuth = (float) Math.Acos((double) num2);
            }
        }

        public static void CreateFromAzimuthAndElevation(float azimuth, float elevation, out Vector3 direction)
        {
            Matrix matrix = Matrix.CreateRotationY(azimuth);
            Matrix matrix2 = Matrix.CreateRotationX(elevation);
            direction = Forward;
            TransformNormal(ref direction, ref matrix2, out direction);
            TransformNormal(ref direction, ref matrix, out direction);
        }

        public float Sum =>
            ((this.X + this.Y) + this.Z);
        public float Volume =>
            ((this.X * this.Y) * this.Z);
        public long VolumeInt(float multiplier) => 
            ((((long) (this.X * multiplier)) * ((long) (this.Y * multiplier))) * ((long) (this.Z * multiplier)));

        public bool IsInsideInclusive(ref Vector3 min, ref Vector3 max) => 
            ((min.X <= this.X) && ((this.X <= max.X) && ((min.Y <= this.Y) && ((this.Y <= max.Y) && ((min.Z <= this.Z) && (this.Z <= max.Z))))));

        public static Vector3 SwapYZCoordinates(Vector3 v) => 
            new Vector3(v.X, v.Z, -v.Y);

        public float GetDim(int i)
        {
            switch (i)
            {
                case 0:
                    return this.X;

                case 1:
                    return this.Y;

                case 2:
                    return this.Z;
            }
            return this.GetDim(((i % 3) + 3) % 3);
        }

        public void SetDim(int i, float value)
        {
            switch (i)
            {
                case 0:
                    this.X = value;
                    return;

                case 1:
                    this.Y = value;
                    return;

                case 2:
                    this.Z = value;
                    return;
            }
            this.SetDim(((i % 3) + 3) % 3, value);
        }

        public static Vector3 Ceiling(Vector3 v) => 
            new Vector3(Math.Ceiling((double) v.X), Math.Ceiling((double) v.Y), Math.Ceiling((double) v.Z));

        public static Vector3 Floor(Vector3 v) => 
            new Vector3(Math.Floor((double) v.X), Math.Floor((double) v.Y), Math.Floor((double) v.Z));

        public static Vector3 Round(Vector3 v) => 
            new Vector3(Math.Round((double) v.X), Math.Round((double) v.Y), Math.Round((double) v.Z));

        public static Vector3 Round(Vector3 v, int numDecimals) => 
            new Vector3(Math.Round((double) v.X, numDecimals), Math.Round((double) v.Y, numDecimals), Math.Round((double) v.Z, numDecimals));

        public static Vector3 ProjectOnPlane(ref Vector3 vec, ref Vector3 planeNormal)
        {
            float num = vec.Dot((Vector3) planeNormal);
            return (vec - ((num / planeNormal.LengthSquared()) * planeNormal));
        }

        public static Vector3 ProjectOnVector(ref Vector3 vec, ref Vector3 guideVector)
        {
            if (IsZero(ref vec) || IsZero(ref guideVector))
            {
                return Zero;
            }
            return ((guideVector * Dot(vec, guideVector)) / guideVector.LengthSquared());
        }

        public static bool IsZero(ref Vector3 vec) => 
            (IsZero(vec.X) && (IsZero(vec.Y) && IsZero(vec.Z)));

        private static bool IsZero(float d) => 
            ((d > -1E-05f) && (d < 1E-05f));
    }
}

