
public class Player : Character
{
    public Player(string name,  int XCoordinate, int YCoordinate, params IComponent[] componentList) : base(name, XCoordinate,YCoordinate, new IComponent[] {new PlayerComponent()})
    {
        this.GetComponentList().AddRange(componentList);
    }
}
