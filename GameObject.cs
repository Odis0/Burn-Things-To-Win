﻿
public class GameObject : IComponent
{
    private string name;
    private List<IComponent> componentList = new List<IComponent>();



    public string GetName()
    {
        return name;
    }

    public List<IComponent> GetComponentList()
    {
        return componentList;
    }

    public void Update(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public LocationComponent GetObjectLocationComponent()
    {
        foreach (IComponent component in componentList)
        {
            if (component is LocationComponent locationComponent)
            {
                return locationComponent;
            }

        }
        return null;
    }
    public GameObject(string name = "", params IComponent[] componentList)
    {
        this.name = name;
        this.componentList.AddRange(componentList);

    }
}
