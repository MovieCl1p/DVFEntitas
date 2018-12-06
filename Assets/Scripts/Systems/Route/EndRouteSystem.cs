using Components;
using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Route
{
    public class EndRouteSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts contexts;
        private readonly IGroup<GameEntity> conveyers;

        public EndRouteSystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
            conveyers = contexts.game.GetGroup(GameMatcher.ComponentsConveyor);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                item.isComponentsEndRoute = false;
                item.RemoveComponentsMove();

                var nextConveyor = GetNextConveyor(item.componentsTransition.ToId);
                if(nextConveyor == null)
                {
                    continue;
                }

                item.AddComponentsAddToRouteCompoent(nextConveyor.componentsRoute);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isComponentsEndRoute && entity.hasComponentsLoadUnit;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsEndRoute.Added());
        }

        private GameEntity GetNextConveyor(string id)
        {
            foreach (var conveyer in conveyers.GetEntities())
            {
                if (conveyer.componentsConveyor.Id == id)
                {
                    return conveyer;
                }
            }

            return null;
        }
    }
}
