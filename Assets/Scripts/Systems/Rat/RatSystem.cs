using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class RatSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts contexts;

        public RatSystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                Vector3 currentLoadPosition = Vector3.zero;
                Vector3 end = Vector3.zero;
                var load = item.componentsLoadUnit;

                //foreach (var destinationPoint in item.componentsRat.DestinationPoints)
                //{
                //    foreach (var routingCode in destinationPoint.RoutingCode)
                //    {
                //        if (load.RoutingCode == routingCode)
                //        {
                //            end = destinationPoint.Position;
                //            break;
                //        }
                //    }

                //}

                //GameEntity routeEntity = contexts.game.CreateEntity();
                //routeEntity.AddComponentsRoute(currentLoadPosition, end, 1, item);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsLoadUnit && entity.hasComponentsRoutingCode;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsRat.Added());
        }
    }
}
