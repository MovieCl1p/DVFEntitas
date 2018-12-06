using Systems;
using Systems.Conveyor;
using Systems.Rat;
using Systems.Route;
using Systems.Transition;
using Transition;
using UnityEngine;

public class AppRoot : MonoBehaviour
{
    private Entitas.Systems _facility;

    public void Start ()
    {
        _facility = CreateFacility(Contexts.sharedInstance);
        _facility.Initialize();
    }

    public void Update()
    {
        _facility.Execute();
    }

    private Entitas.Systems CreateFacility(Contexts contexts)
    {
        Feature feature = new Feature("Facility");

        //IInitializeSystem
        feature.Add(new InitializeTimeSystem(contexts));
        //feature.Add(new InitializeConveyerSystem(contexts)); 
        //feature.Add(new FindRatSustem(contexts));
        feature.Add(new FindConveyerSystem(contexts));

        //IExecuteSystem
        feature.Add(new UpdateTimeSystem(contexts));
        feature.Add(new LoadUnitRenderSystem(contexts));
        feature.Add(new LoadInductSystem(contexts)); 
        feature.Add(new UpdateRouteDataSystem(contexts));
        feature.Add(new MoveAlongRouteSystem(contexts));
        
        //feature.Add(new ConveyerTransitionSystem(contexts));
        //feature.Add(new ConveyorRotationTransitionSystem(contexts));
        //feature.Add(new RatTransitionSystem(contexts)); 


        //ReactiveSystem
        feature.Add(new UpdateChargePointSystem(contexts));
        feature.Add(new DestroySystem(contexts)); 
        feature.Add(new LoadUnitDestroySystem(contexts)); 
        feature.Add(new EndRouteSystem(contexts));
        feature.Add(new AddItemToRouteSystem(contexts));

        //feature.Add(new ChangeColorSystem(contexts)); 

        //feature.Add(new IndexingSystem(contexts));


        //ReactiveSystem renderer
        feature.Add(new ConveyorRenderSystem(contexts));
        //feature.Add(new RatRendererSystem(contexts));

        return feature;
    }
}
