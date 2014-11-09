using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;

namespace MyManagedDirectX
{
    public static class Utility
    {
        public static float DistanceOfTwoVector(Vector3 v1, Vector3 v2)
        {
            float disX = v1.X - v2.X;
            float disY = v1.Y - v2.Y;
            float disZ = v1.Z - v2.Z;
            float distance = (float)Math.Sqrt(disX * disX + disY * disY + disZ * disZ);
            return distance;
        }

        public static float MaxLengthOfSide(Vector3 v1, Vector3 v2)
        {
            float disX = Math.Abs(v1.X - v2.X);
            float disY = Math.Abs(v1.Y - v2.Y);
            float disZ = Math.Abs(v1.Z - v2.Z);

            float maxDis = disX > disY ? disX : disY;
            maxDis = maxDis > disZ ? maxDis : disZ;

            return maxDis;
        }
    }
}
