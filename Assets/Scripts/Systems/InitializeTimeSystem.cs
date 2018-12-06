using Entitas;

namespace Systems
{
    public class InitializeTimeSystem : IInitializeSystem
    {
        private Contexts contexts;

        public InitializeTimeSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            var e = contexts.game.CreateEntity();
            e.AddComponentsDeltaTime(0);
        }
    }
}
