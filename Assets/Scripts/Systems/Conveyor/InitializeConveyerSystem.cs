using Entitas;
using System;
using Systems.Factories;
using UnityEngine;

namespace Systems
{
    public class InitializeConveyerSystem : IInitializeSystem
    {
        private Contexts _contexts;
        private GameObject loadGo;

        public InitializeConveyerSystem(Contexts contexts)
        {
            this._contexts = contexts;
            
        }

        public void Initialize()
        {
            loadGo = Resources.Load<GameObject>("Conveyor");

            //for (int i = 0; i < 1000; i++)
            //{
            //    GameEntity e = _contexts.game.CreateEntity();
            //    e.AddComponentsConveyor("c" + i);
            //    e.AddComponentsLength(10);
            //    e.AddComponentsPosition(new Vector3(i * 4, 0, 0));
            //    e.AddComponentsChargePoint(Vector3.zero, Vector3.zero);
            //    e.AddComponentsLoadInduct(3, 0, true, e);
            //    e.AddComponentsRoute(e.componentsChargePoint.startValue, e.componentsChargePoint.endValue, 2, "");

            //    var cube = GameObject.Instantiate<GameObject>(loadGo);
            //    cube.name = "conveyer " + "c" + i;

            //    e.AddComponentsConveyorRender(cube);

            //}


            //GameEntity e = _contexts.game.CreateEntity();
            //e.AddComponentsConveyor("c");
            //e.AddComponentsLength(1000);
            //e.AddComponentsPosition(new Vector3(0, 0, 0));
            //e.AddComponentsChargePoint(Vector3.zero, Vector3.zero);
            //e.AddComponentsLoadInduct(0.5f, 0, true, e);
            //e.AddComponentsRoute(e.componentsChargePoint.startValue, e.componentsChargePoint.endValue, 2, "");

            //var cube = GameObject.Instantiate<GameObject>(loadGo);
            //cube.name = "conveyer " + "c";

            //e.AddComponentsConveyorRender(cube);
        }
    }
}
