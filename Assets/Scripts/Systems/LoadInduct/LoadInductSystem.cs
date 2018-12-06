using Entitas;
using System;
using Systems.Factories;
using UnityEngine;

namespace Systems
{
    public class LoadInductSystem : IExecuteSystem
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _loadInducts;
        private GameObject loadGo;
        private int _index = 1;

        public LoadInductSystem(Contexts contexts)
        {
            this._contexts = contexts;
            _loadInducts = _contexts.game.GetGroup(GameMatcher.ComponentsLoadInduct);

            loadGo = Resources.Load<GameObject>("Load");
        }

        public void Execute()
        {
            foreach (var item in _loadInducts.GetEntities())
            {
                if(!item.componentsLoadInduct.AutoInduct)
                {
                    continue;
                }

                item.componentsLoadInduct.Counter += Time.deltaTime;
                if (item.componentsLoadInduct.Counter >= item.componentsLoadInduct.InductRate)
                {
                    var start = item.componentsLoadInduct.Conveyor.componentsChargePoint.startValue;
                    var end   = item.componentsLoadInduct.Conveyor.componentsChargePoint.endValue;

                    var load = EntityFactory.CreateLoadUnit(_contexts, start, loadGo);
                    load.ReplaceComponentsRoutingCode(_index == 1 ? "C" : "B");
                    
                    load.AddComponentsAddToRouteCompoent(item.componentsLoadInduct.Conveyor.componentsRoute);

                    item.componentsLoadInduct.Counter = 0;
                    _index *= -1;
                }
            }
        }
    }
}
