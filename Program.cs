using System.ComponentModel;
using System.Runtime.CompilerServices;

Chair chair = new Chair("Chair",new IComponent[] { new LocationComponent(0,0),new FlammableComponent() });
///Armoire armoire = new Armoire();
Investigator investigator = new Investigator();
List<GameObject> gameObjectList = new List<GameObject>() { chair, investigator};


WorldObject world = new WorldObject(3, 3,gameObjectList);
///world.AddObjectToWorld(armoire, 0, 0);
List<GameObject>[,] worldArray = world.GetWorldArray();

while (true)
{
    List<IComponent> chairComponentList = chair.GetComponentList();
    LocationComponent SelectedComponent = (LocationComponent)chairComponentList[0];
    Console.WriteLine(chairComponentList[0]);
    SelectedComponent.PrintObjectLocation();

    
    ///Console.WriteLine(worldArray[0, 0][0].GetName());
    ///Console.WriteLine($"There is a {chair.GetName()} here.");
    Console.ReadLine();
    ///chair.GetComponentList()[1].Activate(chair);
    /*
    Console.WriteLine($"There is an {armoire.GetName()} here.");
    Console.ReadLine();
    armoire.GetComponentList()[0].Activate(armoire);
    */
}


public class Investigator : GameObject
{

    public Investigator(): base("Investigator", componentList: new IComponent[] {new PlayerComponent(),new LocationComponent(0,0), new MoveableComponent() }) { }

}


public class MoveableComponent : GameObject, IComponent
{
    public void MoveObject(GameObject gameObject, int xDestination, int yDestination)
    {
        foreach (IComponent component in gameObject.GetComponentList())
        {
            if (component is LocationComponent locationComponent)
            {
                locationComponent.SetXLocation(xDestination);
                locationComponent.SetYLocation(yDestination);

            }

        }
    }
}

public class PlayerComponent : GameObject, IComponent
{

}

public class LocationComponent: GameObject, IComponent
{
    private int xLocation;
    private int yLocation;

    public int GetXLocation() { return xLocation; }
    public int GetYLocation() { return yLocation; }

    public void SetXLocation(int xLocation) { this.xLocation = xLocation; }

    public void SetYLocation(int yLocation) { this.yLocation = yLocation; }

    public void PrintObjectLocation()
    {
        Console.WriteLine($"({this.xLocation},{this.yLocation})");
    }
    public LocationComponent(int xLocation, int yLocation)
    {
        this.xLocation = xLocation;
        this.yLocation = yLocation;


    }



}



public class WorldObject
{
    private List<GameObject>[,] worldArray;


    public List<GameObject>[,] GetWorldArray()
    {
        return worldArray;
    }

    public void AddObjectToWorld(GameObject targetObject, int xLocation, int yLocation)
    {
        worldArray[xLocation, yLocation].Add(targetObject);
    }


    public WorldObject(int width, int height, List<GameObject> gameObjectList)
    {

        GameObject gameObject = new GameObject();

        worldArray = new List<GameObject>[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                worldArray[i, j] = new List<GameObject>();
            }
        }

        foreach (GameObject obj in gameObjectList)
        {
            List<IComponent> objectComponentList = obj.GetComponentList();
            foreach (IComponent component in objectComponentList)
            {
                if (component is LocationComponent locationComponent)
                {
                    int xLocation = locationComponent.GetXLocation();
                    int yLocation = locationComponent.GetYLocation();

                    worldArray[xLocation, yLocation].Add(obj);
                }
            }
        }


    }
}