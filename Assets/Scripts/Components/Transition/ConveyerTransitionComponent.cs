using Entitas;
using UnityEngine;

namespace Components
{
    public class ConveyerTransitionComponent : IComponent
    {
        public string To;
        public float Distance;
        public Vector3 EndPoint;
    }
}
