using Entitas;
using UnityEngine;

namespace Systems.Transition
{
    public class RatTransitionSystem : IExecuteSystem
    {
        private readonly Contexts contexts;
        private readonly IGroup<GameEntity> entites;
        private readonly IGroup<GameEntity> rats;

        public RatTransitionSystem(Contexts contexts)
        {
            this.contexts = contexts;
            entites = contexts.game.GetGroup(GameMatcher.ComponentsRatTransition);
            rats = contexts.game.GetGroup(GameMatcher.ComponentsRat);
        }

        public void Execute()
        {
            //foreach (var load in entites.GetEntities())
            //{
            //    foreach (var rat in rats.GetEntities())
            //    {
            //        if (rat.componentsConveyor.Id != load.componentsRatTransition.To)
            //        {
            //            continue;
            //        }

            //        for (int i = 0; i < rat.componentsRat.DestinationPoints.Count; i++)
            //        {
            //            var p = rat.componentsRat.DestinationPoints[i];
            //            if (p.RoutingCode == load.componentsRoutingCode.RoutingCode)
            //            {
            //                load.ReplaceComponentsPosition(Vector3.MoveTowards(load.componentsPosition.value, p.Position, 1 * Time.deltaTime));
            //                float dist = Vector3.Distance(load.componentsPosition.value, p.Position);
            //                if (dist <= 1 * Time.deltaTime)
            //                {
            //                    var conveyers = contexts.game.GetGroup(GameMatcher.ComponentsConveyor);
            //                    foreach (var conveyer in conveyers.GetEntities())
            //                    {
            //                        if(p.Next == conveyer.componentsConveyor.Id)
            //                        {
            //                            load.ReplaceComponentsMove(conveyer.componentsChargePoint.endValue, conveyer.componentsRoute.Velocity);
            //                            load.RemoveComponentsRatTransition();
            //                            break;
            //                        }
            //                    }
            //                }
            //                break;
            //            }
            //        }
            //    }

            //}
        }
    }
}
