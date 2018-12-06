using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class RatRendererSystem : ReactiveSystem<GameEntity>
    {
        public RatRendererSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                item.componentsRatRenderer.value.transform.position = new Vector3(item.componentsPosition.value.X, item.componentsPosition.value.Y, item.componentsPosition.value.Z);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsRatRenderer && entity.hasComponentsPosition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ComponentsRatRenderer, GameMatcher.ComponentsPosition));
        }
    }
}
