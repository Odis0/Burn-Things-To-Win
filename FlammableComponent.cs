
public class FlammableComponent : GameObject, IComponent
{

    void IComponent.Activate(GameObject gameObject)
    {
        Console.WriteLine($"The {gameObject.GetName()} catches fire and burns to ash.");
    }
}
