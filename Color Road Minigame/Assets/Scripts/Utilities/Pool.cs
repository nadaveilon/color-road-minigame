using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class Pool<T> : MonoBehaviour where T : UnityEngine.Object
    {
        public List<T> availableObjects;
        public List<T> objectsInUse;

        public Pool(T original, int size)
        {
            availableObjects = new List<T>(size);
            objectsInUse = new List<T>(size);

            for (int i = 0; i < size; i++)
            {
                availableObjects.Add(Instantiate(original));
            }
        }

        public T Withdraw()
        {
            var instance = availableObjects.First();
            objectsInUse.Add(instance);
            availableObjects.Remove(instance);
            return instance;
        }

        public void Deposit(T instance)
        {
            objectsInUse.Remove(instance);
            availableObjects.Add(instance);
        }
    }
}
