using Data;
using Entitas;
using System.Collections.Generic;

namespace Components
{
    public class RatComponent : IComponent
    {
        public List<RatDestinationPoint> DestinationPoints;
        public float Velocity;
    }
}
