using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[Game, Unique]
public class GameObjectsRootComponent : IComponent
{
    public GameObject value;
}

[Game, Unique]
public class ClicksToColorVariantComponent : IComponent
{
    public ClicksToColor[] list;
}

[Game]
public class ColorComponent : IComponent {
    public Color color;
}


[Game, Unique]
public class ClicksComponent : IComponent
{
}

[Game]
public class TotalClicksNumberComponent : IComponent
{
    public int totalClicks;
}

[Game]
public sealed class PositionComponent : IComponent
{
    public Vector2 value;
}

[Game]
public sealed class ViewComponent : IComponent
{
    public GameObject gameObject;
}

[Game]
public sealed class MovableSpriteComponent : IComponent
{
}

[Input, Unique]
public class CurrentTarget : IComponent {
    public GameEntity entityRef;
}

[Input, Unique]
public class LeftMouseComponent : IComponent
{
}

[Input]
public class MouseDownComponent : IComponent
{
    public Vector2 position;
}

[Input]
public class MouseUpComponent : IComponent
{
    public Vector2 position;
}

[Input]
public class MousePositionComponent : IComponent
{
    public Vector2 position;
}
