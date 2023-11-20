
public class Character:GameObject
{
    public Character(string name,int XCoordinate, int YCoordinate, params IComponent[] componentList) : base(name, new LocationComponent(XCoordinate, YCoordinate))
    {
        this.GetComponentList().AddRange(componentList);
    }

}
