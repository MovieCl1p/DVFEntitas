using Components;
using Entitas;
using System;

namespace Systems
{
    public class MoveAlongRouteSystem : IExecuteSystem
    {
        private Contexts contexts;
        private IGroup<GameEntity> entities;
        private DeltaTimeComponent time;

        public MoveAlongRouteSystem(Contexts contexts)
        {
            this.contexts = contexts;
            entities = contexts.game.GetGroup(GameMatcher.ComponentsMove);
        }

        public void Execute()
        {
            time = contexts.game.GetEntities(GameMatcher.ComponentsDeltaTime)[0].componentsDeltaTime;

            foreach (var item in entities.GetEntities())
            {
                var t = item.componentsMove.Velocity * time.value;

                item.componentsPosition.value.Z = item.componentsPosition.value.Z + t;
                float dist = Math.Abs( (item.componentsMove.EndPosition.Z - item.componentsPosition.value.Z) );
                if (dist <= t)
                {
                    item.componentsPosition.value.Z = item.componentsMove.EndPosition.Z;
                    item.isComponentsEndRoute = true;
                }

                //item.ReplaceComponentsPosition(item.componentsPosition.value);

                //var end = new Vector3(item.componentsMove.EndPosition.X, item.componentsMove.EndPosition.Y, item.componentsMove.EndPosition.Z);
                //var t = item.componentsMove.Velocity * Time.deltaTime;
                //var pos = new Vector3(item.componentsPosition.value.X, item.componentsPosition.value.Y, item.componentsPosition.value.Z);
                //var newV = Vector3.MoveTowards(pos, end, t);
                //Position newpos = new Position
                //{
                //    X = newV.x,
                //    Y = newV.y,
                //    Z = newV.z

                //};
                //item.ReplaceComponentsPosition(newpos);

                //float dist = Vector3.Distance(pos, end);
                //if (dist <= t)
                //{
                //    item.isComponentsEndRoute = true;
                //}
            }
        }
    }
}
