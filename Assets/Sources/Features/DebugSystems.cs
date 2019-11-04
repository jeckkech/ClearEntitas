using Entitas;

public class DebugSystems : Feature
{
    public DebugSystems(Contexts contexts) : base("Debug Systems")
    {
        Add(new DebugMessageSystem(contexts));
        Add(new CleanupDebugMessageSystem(contexts));
    }
}
