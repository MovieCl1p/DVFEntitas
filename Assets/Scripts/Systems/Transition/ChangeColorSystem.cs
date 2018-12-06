using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Transition
{
    public class ChangeColorSystem : ReactiveSystem<GameEntity>
    {
        public ChangeColorSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var item in entities)
            {
                item.componentsLoadUnitRender.value.GetComponent<Renderer>().material.color = Color.red;
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsLoadUnitRender;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsConveyerTransition.Added());
        }
    }
}
