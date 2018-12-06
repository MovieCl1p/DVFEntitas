using Entitas;
using System;
using Systems.Factories;
using UnityEngine;

namespace Systems
{
    public class FindLoadUnitsSystem : IInitializeSystem
    {
        private Contexts _contexts;

        public FindLoadUnitsSystem(Contexts contexts)
        {
            this._contexts = contexts;
        }

        public void Initialize()
        {
            var loads = GameObject.FindObjectsOfType<LoadUnitMono>();
            for (int i = loads.Length - 1; i >= 0; i--)
            {
                //EntityFactory.CreateLoadUnit(_contexts, Vector3.zero, string.Empty);
                //GameObject.Destroy(loads[i].gameObject);
            }
        }
    }
}
