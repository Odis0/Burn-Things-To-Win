using System.Runtime.CompilerServices;

Chair chair = new Chair();
Armoire armoire = new Armoire();
WorldObject world = new WorldObject(3, 3);
world.AddObjectToWorld(armoire, 0, 0);
List<GameObject>[,] worldArray = world.GetWorldArray();

while (true)
{
    Console.WriteLine(worldArray[0, 0][0].GetName());
    Console.WriteLine($"There is a {chair.GetName()} here.");
    Console.ReadLine();
    chair.GetAttributeList()[0].Activate(chair);
    
    Console.WriteLine($"There is an {armoire.GetName()} here.");
    Console.ReadLine();
    armoire.GetAttributeList()[0].Activate(armoire);

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


    public WorldObject(int width, int height)
    {
        worldArray = new List<GameObject>[width, height];
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                worldArray[i, j] = new List<GameObject>();
            }
        }
        
    }
}