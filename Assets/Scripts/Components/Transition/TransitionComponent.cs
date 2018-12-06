using Entitas;

namespace Components
{
    public class TransitionComponent : IComponent
    {
        public string FromId;
        public string ToId;
    }
}
