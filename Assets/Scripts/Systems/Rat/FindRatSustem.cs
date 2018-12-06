using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Systems.Factories;
using Unity;
using UnityEngine;

namespace Systems.Rat
{
    public class FindRatSustem : IInitializeSystem
    {
        private Contexts contexts;

        public FindRatSustem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            var loads = GameObject.FindObjectsOfType<RatMono>();
            for (int i = loads.Length - 1; i >= 0; i--)
            {
                EntityFactory.CreateRat(contexts, loads[i]);
                GameObject.Destroy(loads[i].gameObject);
            }
        }
    }
}
