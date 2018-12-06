using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems
{
    public class UpdateTransitionItemSystem : ReactiveSystem<GameEntity>
    {
        public UpdateTransitionItemSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsTransition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsTransition.Added());
        }
    }
}
