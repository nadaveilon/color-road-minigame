using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Utilities
{
    public static class Extensions
    {
        private static Random random = new Random();

        // Shuffle a generic list using the Fisher-Yates shuffle algorithm
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void SetPositionX(this Transform transform, float newX)
        {
            var pos = transform.position;
            pos.x = newX;
            transform.position = pos;
        }

        public static void SetPositionZ(this Transform transform, float newZ)
        {
            var pos = transform.position;
            pos.z = newZ;
            transform.position = pos;
        }
    }
}
