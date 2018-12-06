using Data;
using Entitas;
using System.Collections.Generic;

namespace Systems
{
    public class UpdateRouteDataSystem : ReactiveSystem<GameEntity>
    {
        public UpdateRouteDataSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                Position start = new Position
                {
                    X = item.componentsChargePoint.startValue.x,
                    Y = item.componentsChargePoint.startValue.y,
                    Z = item.componentsChargePoint.startValue.z

                };
                Position end = new Position
                {
                    X = item.componentsChargePoint.endValue.x,
                    Y = item.componentsChargePoint.endValue.y,
                    Z = item.componentsChargePoint.endValue.z

                };

                item.ReplaceComponentsRoute(start, end, item.componentsRoute.Velocity, item.componentsRoute.TransitionToId);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsRoute && entity.hasComponentsChargePoint;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsChargePoint);
        }
    }
}
