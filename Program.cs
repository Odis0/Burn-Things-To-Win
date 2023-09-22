Chair chair = new Chair();
Armoire armoire = new Armoire();

while (true)
{
    
    Console.WriteLine($"There is a {chair.GetName()} here.");
    Console.ReadLine();
    chair.GetAttributeList()[0].Activate(chair);
    
    Console.WriteLine($"There is an {armoire.GetName()} here.");
    Console.ReadLine();
    armoire.GetAttributeList()[0].Activate(armoire);

}
public class GameObject: IAttribute  
{
    private string name;
    private List<IAttribute> attributeList = new List<IAttribute>();
    public string GetName()
    {
        return name;
    }

    public List<IAttribute> GetAttributeList()
    {
        return attributeList;
    }

    public void Activate(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public GameObject(string name, List<IAttribute> attributeList)
    {
        this.name = name;
        this.attributeList = attributeList;
    }
}
public interface IAttribute
{
    void Activate(GameObject gameObject);
}

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

public class Chair : GameObject
{


    public Chair() : base(name:"Chair", attributeList : new List<IAttribute>(){new FlammableComponent()})
    {
        
    }
}

public class Armoire : GameObject
{

    public Armoire() : base(name: "Armoire", attributeList: new List<IAttribute>() { new FlammableComponent() })
    {

    }

}