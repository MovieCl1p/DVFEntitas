using Entitas;
using UnityEngine;

namespace Components
{
    public class LoadInductComponent : IComponent
    {
        public float InductRate;
        public float Counter;
        public bool AutoInduct;
        public GameEntity Conveyor;
    }
}
