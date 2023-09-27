
public class Armoire : GameObject
{
    public Armoire() : base(name: "Armoire", componentList: new IComponent[] {new FlammableComponent() }) { }



}