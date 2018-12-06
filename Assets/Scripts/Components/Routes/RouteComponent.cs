using Data;
using Entitas;

namespace Components
{
    public class RouteComponent : IComponent
    {
        public Position StartPosition;
        public Position EndPosition;
        public float Velocity;
        public string TransitionToId;
    }
}
