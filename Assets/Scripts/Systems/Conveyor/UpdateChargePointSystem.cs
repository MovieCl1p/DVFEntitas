using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class UpdateChargePointSystem : ReactiveSystem<GameEntity>
    {
        public UpdateChargePointSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                Transform conveyorTransform = item.componentsConveyorRender.value.transform;
                Vector3 pos = new Vector3(item.componentsPosition.value.X, item.componentsPosition.value.Y, item.componentsPosition.value.Z);
                Vector3 start = pos - (conveyorTransform.forward * (item.componentsLength.value * 0.5f)) + (conveyorTransform.up * (conveyorTransform.lossyScale.y * 0.5f));
                Vector3 end = pos + (conveyorTransform.forward * (item.componentsLength.value * 0.5f)) + (conveyorTransform.up * (conveyorTransform.lossyScale.y * 0.5f));

                item.ReplaceComponentsChargePoint(start, end);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsLength && entity.hasComponentsConveyorRender && entity.hasComponentsChargePoint;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ComponentsConveyorRender, GameMatcher.ComponentsLength, GameMatcher.ComponentsPosition));
        }
    }
}
