using Data;
using Entitas;

namespace Components
{
    public class MoveComponent : IComponent
    {
        public Position EndPosition;
        public float Velocity;
    }
}
