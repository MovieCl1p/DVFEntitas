using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems
{
    public class DestroySystem : ReactiveSystem<GameEntity>
    {
        public DestroySystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                item.Destroy();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isComponentsDestroy;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsDestroy.Added());
        }
    }
}
