using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems.Transition
{
    public class ConveyorRotationTransitionSystem : IExecuteSystem
    {
        private readonly Contexts contexts;
        private readonly IGroup<GameEntity> entites;

        public ConveyorRotationTransitionSystem(Contexts contexts)
        {
            this.contexts = contexts;
            entites = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ComponentsConveyerTransition, GameMatcher.ComponentsPosition));
        }

        public void Execute()
        {
            foreach (var load in entites.GetEntities())
            {
                var conveyers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ComponentsConveyor, GameMatcher.ComponentsChargePoint, GameMatcher.ComponentsRoute));
                foreach (var conveyer in conveyers)
                {
                    if (conveyer.componentsConveyor.Id != load.componentsConveyerTransition.To)
                    {
                        continue;
                    }

                    var pos = new Vector3(load.componentsPosition.value.X, load.componentsPosition.value.Y, load.componentsPosition.value.Z);
                    float dist = Vector3.Distance(pos, conveyer.componentsChargePoint.startValue);
                    load.componentsLoadUnitRender.value.transform.rotation = Quaternion.Lerp(
                                                                                load.componentsLoadUnitRender.value.transform.rotation, 
                                                                                conveyer.componentsConveyorRender.value.transform.rotation,
                                                                                ((load.componentsConveyerTransition.Distance - dist) / load.componentsConveyerTransition.Distance));
                }

            }
        }
    }
}
