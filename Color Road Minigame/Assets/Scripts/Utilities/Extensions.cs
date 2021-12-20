using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Utilities
{
    public static class Extensions
    {
        private static Random random = new Random();

        /// <summary>
        /// Shuffle a generic list using the Fisher-Yates shuffle algorithm 
        /// </summary>
        /// <typeparam name="T">The data type of the list's items</typeparam>
        /// <param name="list">The list to shuffle</param>
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

        /// <summary>
        /// Set only the X value of the position component of a transform
        /// </summary>
        /// <param name="transform">The transform to modify</param>
        /// <param name="newX">The new X value</param>
        public static void SetPositionX(this Transform transform, float newX)
        {
            var pos = transform.position;
            pos.x = newX;
            transform.position = pos;
        }

        /// <summary>
        /// Set only the Z value of the position component of a transform
        /// </summary>
        /// <param name="transform">The transform to modify</param>
        /// <param name="newZ">The new Z value</param>
        public static void SetPositionZ(this Transform transform, float newZ)
        {
            var pos = transform.position;
            pos.z = newZ;
            transform.position = pos;
        }
    }
}
