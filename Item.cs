public class Item : GameObject
{
    public Item(string name, params IComponent[] componentList) : base(name)
    {
        this.GetComponentList().AddRange(componentList);
    }
}
