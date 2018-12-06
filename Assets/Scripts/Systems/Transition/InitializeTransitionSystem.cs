using Entitas;

namespace Systems
{
    public class InitializeTransitionSystem : IInitializeSystem
    {
        private Contexts contexts;

        public InitializeTransitionSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            //var e = contexts.game.CreateEntity();
            //e.AddComponentsTransition("Conveyer1", "Rat1");
        }
    }
}
