using Entitas;

public class ClicksToColorSystems : Feature
{
    public ClicksToColorSystems(Contexts contexts) : base("Clicks to color Systems")
    {
        Add(new ClickCounterSystem(contexts));               
        Add(new RenderColorSystem(contexts));
        Add(new RenderPositionSystem(contexts));
    }
}
