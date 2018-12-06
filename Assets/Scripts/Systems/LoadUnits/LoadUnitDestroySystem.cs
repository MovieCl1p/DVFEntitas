using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems
{
    public class LoadUnitDestroySystem : ReactiveSystem<GameEntity>
    {
        public LoadUnitDestroySystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                GameObject.Destroy(item.componentsLoadUnitRender.value);
                item.Destroy();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isComponentsLoadUnitDestroy && entity.hasComponentsLoadUnitRender;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsLoadUnitDestroy.Added());
        }
    }
}
