
public class Character:GameObject
{
    public Character(string name, int XCoordinate, int YCoordinate, params IComponent[] componentList) : base(name)
    {
        this.GetComponentList().AddRange(componentList);
    }

}
