using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems
{
    public class UpdateTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public UpdateTimeSystem(Contexts contexts)
        {
            entities = contexts.game.GetGroup(GameMatcher.ComponentsDeltaTime);
        }

        public void Execute()
        {
            foreach (var item in entities.GetEntities())
            {
                item.componentsDeltaTime.value = Time.deltaTime;
            }
        }
    }
}
