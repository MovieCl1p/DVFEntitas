using Components;
using Data;
using Entitas;
using System;
using UnityEngine;

namespace Systems
{
    public class InitializeRatSystem : IInitializeSystem
    {
        private readonly Contexts contexts;

        public InitializeRatSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            //GameEntity e = contexts.game.CreateEntity();

            
            //e.AddComponentsRat()
        }

        private void CreateRat()
        {
            //RatDestinationPoint point = new RatDestinationPoint();
        }

    }
}
