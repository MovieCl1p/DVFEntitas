using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems
{
    public class IndexingSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> conveyors;

        public IndexingSystem(Contexts contexts) : base(contexts.game)
        {
            conveyors = contexts.game.GetGroup(GameMatcher.ComponentsConveyor);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                //var conveyor = item.componentsAddToRouteCompoent.Conveyor;
                //if (conveyor == null || !conveyor.hasComponentsIndexZone)
                //{
                //    continue;
                //}

                //if(conveyor.componentsIndexZone.Last-1 == conveyor.componentsIndexZone.Zones)
                //{
                //    continue;
                //}

                //var dir = conveyor.componentsChargePoint.endValue - conveyor.componentsChargePoint.startValue;
                //float k = dir.magnitude / conveyor.componentsIndexZone.Zones;
                //var end = conveyor.componentsChargePoint.endValue - (dir.normalized * (k * conveyor.componentsIndexZone.Last));

                //conveyor.componentsIndexZone.Last++;

                //conveyor.componentsRoute.EndPosition = end;
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsAddToRouteCompoent;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsAddToRouteCompoent.Added());
        }

        private GameEntity GetConveyor(string id)
        {
            foreach (var conveyor in conveyors.GetEntities())
            {
                if (conveyor.componentsConveyor.Id == id)
                {
                    return conveyor;
                }
            }

            return null;
        }
    }
}
