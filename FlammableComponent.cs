
public class FlammableComponent : GameObject, IComponent
{

    void IComponent.Update(GameObject gameObject)
    {
        Console.WriteLine($"The {gameObject.GetName()} catches fire and burns to ash.");
    }
}
