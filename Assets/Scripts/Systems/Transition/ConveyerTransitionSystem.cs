using Data;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class ConveyerTransitionSystem : IExecuteSystem
    {
        private readonly Contexts contexts;
        private readonly IGroup<GameEntity> entites;
        private readonly IGroup<GameEntity> conveyers;

        public ConveyerTransitionSystem(Contexts contexts)
        {
            this.contexts = contexts;
            entites = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ComponentsConveyerTransition, GameMatcher.ComponentsPosition));
            conveyers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ComponentsConveyor, GameMatcher.ComponentsChargePoint, GameMatcher.ComponentsRoute));
        }

        public void Execute()
        {
            foreach (var load in entites.GetEntities())
            {
                foreach (var conveyer in conveyers.GetEntities())
                {
                    if(conveyer.componentsConveyor.Id != load.componentsConveyerTransition.To)
                    {
                        continue;
                    }
                    
                    var pos = new Vector3(load.componentsPosition.value.X, load.componentsPosition.value.Y, load.componentsPosition.value.Z);
                    var newV = Vector3.MoveTowards(pos, conveyer.componentsChargePoint.startValue, 1 * Time.deltaTime);
                    Position newpos = new Position
                    {
                        X = newV.x,
                        Y = newV.y,
                        Z = newV.z

                    };
                    load.ReplaceComponentsPosition(newpos);

                    float dist = Vector3.Distance(pos, conveyer.componentsChargePoint.startValue);
                    if (dist <= 1 * Time.deltaTime)
                    {
                        load.RemoveComponentsConveyerTransition();
                        load.AddComponentsAddToRouteCompoent(conveyer.componentsRoute);
                        break;
                    }
                }

            }
        }
        
    }
}
