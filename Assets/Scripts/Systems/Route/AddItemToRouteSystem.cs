using Entitas;
using System.Collections.Generic;

namespace Systems
{
    public class AddItemToRouteSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> conveyors;

        public AddItemToRouteSystem(Contexts contexts) : base(contexts.game)
        {
            conveyors = contexts.game.GetGroup(GameMatcher.ComponentsConveyor);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                var component = item.componentsAddToRouteCompoent;
                item.AddComponentsMove(component.Route.EndPosition, component.Route.Velocity);
                //item.ReplaceComponentsTransition(item.componentsAddToRouteCompoent.ConveyorId, item.Route.TransitionToId);
                item.RemoveComponentsAddToRouteCompoent();
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
    }
}
