
public class Chair : GameObject
{


    public Chair() : base(name:"Chair", attributeList : new List<IAttribute>(){new FlammableComponent()})
    {
        
    }
}
