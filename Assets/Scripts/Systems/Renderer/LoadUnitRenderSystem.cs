using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class LoadUnitRenderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public LoadUnitRenderSystem(Contexts contexts)
        {
            entities = contexts.game.GetGroup(GameMatcher.ComponentsLoadUnitRender);
        }

        public void Execute()
        {
            foreach (var item in entities.GetEntities())
            {
                item.componentsLoadUnitRender.value.transform.position = new Vector3(item.componentsPosition.value.X, item.componentsPosition.value.Y, item.componentsPosition.value.Z);
            }
        }
    }
}
