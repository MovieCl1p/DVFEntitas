using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class ConveyorRenderSystem : ReactiveSystem<GameEntity>
    {
        public ConveyorRenderSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                Vector3 s = item.componentsConveyorRender.value.transform.localScale;
                s.z = item.componentsLength.value;
                item.componentsConveyorRender.value.transform.localScale = s;

                item.componentsConveyorRender.value.transform.position = new Vector3(item.componentsPosition.value.X, item.componentsPosition.value.Y, item.componentsPosition.value.Z);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsConveyorRender && entity.hasComponentsLength && entity.hasComponentsPosition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(
                                            GameMatcher.ComponentsConveyorRender,
                                            GameMatcher.ComponentsLength, GameMatcher.ComponentsPosition));
        }
    }
}
