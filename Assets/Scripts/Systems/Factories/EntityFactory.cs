using Data;
using System;
using Unity;
using UnityEngine;

namespace Systems.Factories
{
    public static class EntityFactory
    {

        public static GameEntity CreateLoadUnit(Contexts contexts, Vector3 currentPosition, GameObject prefab)
        {
            Position pos = new Position
            {
                X = currentPosition.x,
                Y = currentPosition.y,
                Z = currentPosition.z

            };
            string id = Guid.NewGuid().ToString();
            var e = contexts.game.CreateEntity();
            e.AddComponentsLoadUnit(id);
            e.AddComponentsPosition(pos);
            e.AddComponentsRoutingCode("C");

            var go = GameObject.Instantiate(prefab);
            go.name = id;
            e.AddComponentsLoadUnitRender(go);

            return e;
        }

        public static GameEntity CreateConveyer(Contexts contexts, float currentPosition, float length, string id, string nextConveyor, bool induct)
        {
            Position pos = new Position
            {
                X = 0,
                Y = 0,
                Z = currentPosition

            };

            GameEntity e = contexts.game.CreateEntity();
            e.AddComponentsConveyor(id);
            e.AddComponentsLength(length);
            e.AddComponentsPosition(pos);
            e.AddComponentsChargePoint(Vector3.zero, Vector3.zero);

            if (induct)
            {
                e.AddComponentsLoadInduct(2, 0, true, e);
            }

            Position start = new Position
            {
                X = e.componentsChargePoint.startValue.x,
                Y = e.componentsChargePoint.startValue.y,
                Z = e.componentsChargePoint.startValue.z

            };
            Position end = new Position
            {
                X = e.componentsChargePoint.endValue.x,
                Y = e.componentsChargePoint.endValue.y,
                Z = e.componentsChargePoint.endValue.z

            };
            e.AddComponentsRoute(start, end, 2, nextConveyor);

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(1, 0.1f, 1);
            cube.name = "conveyer " + id;
            cube.transform.rotation = Quaternion.identity;

            e.AddComponentsConveyorRender(cube);

            return e;
        }
        
        public static void CreateConveyer(Contexts contexts, ConveyerMono conveyerMono)
        {
            Position pos = new Position
            {
                X = conveyerMono.transform.position.x,
                Y = conveyerMono.transform.position.y,
                Z = conveyerMono.transform.position.z

            };

            GameEntity e = contexts.game.CreateEntity();
            e.AddComponentsConveyor(conveyerMono.Id);
            e.AddComponentsLength(conveyerMono.Length);
            e.AddComponentsPosition(pos);
            e.AddComponentsChargePoint(Vector3.zero, Vector3.zero);

            if(conveyerMono.IsLoadInduct)
            {
                e.AddComponentsLoadInduct(conveyerMono.InductRate, 0, true, e);
            }

            Position start = new Position { X = e.componentsChargePoint.startValue.x,
                                            Y = e.componentsChargePoint.startValue.y,
                                            Z = e.componentsChargePoint.startValue.z

            };
            Position end = new Position
            {
                X = e.componentsChargePoint.endValue.x,
                Y = e.componentsChargePoint.endValue.y,
                Z = e.componentsChargePoint.endValue.z

            };
            e.AddComponentsRoute(start, end, conveyerMono.Velocity, conveyerMono.Next);

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(1, 0.1f, 1);
            cube.name = "conveyer " + conveyerMono.Id;
            cube.transform.rotation = conveyerMono.transform.rotation;

            e.AddComponentsConveyorRender(cube);
        }

        public static void CreateIndexing(Contexts contexts, IndexingConveyerMono conveyerMono)
        {
            //GameEntity e = contexts.game.CreateEntity();
            //e.AddComponentsConveyor(conveyerMono.Id);
            //e.AddComponentsLength(conveyerMono.Length);
            //e.AddComponentsPosition(conveyerMono.transform.position);
            //e.AddComponentsChargePoint(Vector3.zero, Vector3.zero);

            //var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.localScale = new Vector3(1, 0.1f, 1);
            //cube.name = "index " + conveyerMono.Id;
            //cube.transform.rotation = conveyerMono.transform.rotation;

            //e.AddComponentsConveyorRender(cube);
            //e.AddComponentsRoute(e.componentsChargePoint.startValue, e.componentsChargePoint.endValue, conveyerMono.Velocity, "");
            //e.AddComponentsIndexZone(conveyerMono.Zones, 0);

            //e.AddComponentsLoadInduct(5, 0, true, e);
        }

        public static void CreateRat(Contexts contexts, RatMono ratMono)
        {
            Position pos = new Position
            {
                X = ratMono.transform.position.x,
                Y = ratMono.transform.position.y,
                Z = ratMono.transform.position.z

            };
            var e = contexts.game.CreateEntity();
            e.AddComponentsConveyor("Rat1");
            e.AddComponentsRat(ratMono.GetDestinationPoints(), 1);
            e.AddComponentsPosition(pos);
            //e.AddComponentsRoute(Vector3.zero, Vector3.zero, 2, "C1", new System.Collections.Generic.List<string>());

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(2, 0.1f, 2);
            cube.name = "Rat";

            e.AddComponentsRatRenderer(cube);
        }
    }
}
