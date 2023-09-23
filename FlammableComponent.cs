
public class FlammableComponent : GameObject, IAttribute
{
    string? name;
    public FlammableComponent() : base(name: "Flammable", attributeList: new List<IAttribute>())
    {
    }

    void IAttribute.Activate(GameObject gameObject)
    {
        Console.WriteLine($"The {gameObject.GetName()} catches fire and burns to ash.");
    }
}
