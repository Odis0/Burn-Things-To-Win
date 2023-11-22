class PlayerUI

{
    GameObject playerObject;
    public PlayerUI(GameObject playerObject)
    {
        this.playerObject = playerObject;
 
    }

    public void DisplayUITopLevel()
    {
        while (true)
        {
          /*  Console.WriteLine();
            DisplayPlayerRoomName(player);
            Console.WriteLine();
          */

            int input0 = DisplayMainActionMenu();
            switch (input0)
            {
                case 0:
                    DisplayMoveActionMenu();
                    break;
                default:
                    Console.WriteLine("That's not a valid option.");
                    break;
            }
            break;

        }

    }


    public int DisplayMainActionMenu()
    {
        Console.WriteLine("What would you like to do?\n");
        Console.WriteLine("0: Move");
        Console.WriteLine("1: Interact");
        Console.WriteLine("2: Inventory");

        int playerInput = GetPlayerInput();
        return playerInput;

    }

    public void DisplayMoveActionMenu()
    {
        while (true)
        {
           
            Console.WriteLine("Where would you like to move?\n");

            int i = 0;
            List<Room> Connection = new List<Room>();
            /*
            foreach(IComponent c in playerObject.parentSpace.parentObject.componentList)
            {
                if (c is NauticalComponent)
                {
                    Console.WriteLine($"{i}:{((NauticalComponent)c).connectingRoom.GetName()} - {((NauticalComponent)c).direction}");
                    Connection.Add(((NauticalComponent)c).connectingRoom);
                    i++;
                }
                
            }*/
            
                
            /*

            Console.WriteLine($"{i}: Back");
            int playerinput0 = GetPlayerInput();
            if (playerinput0 >= 0 && playerinput0 < i)
            {
                ((SpaceComponent)Connection[playerinput0].componentList[0]).gameObjectList.Add(playerObject);
                playerObject.parentSpace.gameObjectList.Remove(playerObject);
                playerObject.parentSpace = ((SpaceComponent)Connection[playerinput0].componentList[0]);
                
                break;            
            }*/
            

        }
    }




    

    public int GetPlayerInput()
    {
        while (true)
        {
            string playerInput = Console.ReadLine();

            // Check if the input is empty (null or whitespace)
            if (string.IsNullOrWhiteSpace(playerInput))
            {
                Console.WriteLine("What was that?");
                continue; // Go back to the start of the loop
            }

            // Try to parse the input as an integer
            if (int.TryParse(playerInput, out int intValue))
            {
                return intValue; // Return the parsed integer
            }
            else
            {
                Console.WriteLine("Please input an integer");
            }
        }
    }
}


