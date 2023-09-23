
public class Armoire : GameObject
{

    public Armoire() : base(name: "Armoire", attributeList: new List<IAttribute>() { new FlammableComponent() })
    {

    }

}