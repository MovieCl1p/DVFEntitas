using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Systems.Factories;
using Unity;
using UnityEngine;

namespace Systems.Conveyor
{
    public class FindConveyerSystem : IInitializeSystem
    {
        private Contexts contexts;

        public FindConveyerSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            var conveyors = GameObject.FindObjectsOfType<ConveyerMono>();
            for (int i = conveyors.Length - 1; i >= 0; i--)
            {
                EntityFactory.CreateConveyer(contexts, conveyors[i]);
                GameObject.Destroy(conveyors[i].gameObject);
            }

            var indexings = GameObject.FindObjectsOfType<IndexingConveyerMono>();
            for (int i = indexings.Length - 1; i >= 0; i--)
            {
                EntityFactory.CreateIndexing(contexts, indexings[i]);
                GameObject.Destroy(indexings[i].gameObject);
            }
        }
    }
}
