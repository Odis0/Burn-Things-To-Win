class PlayerUI

{
    GameObject playerObject;
    GameObjectList gameObjectList;
    public PlayerUI(GameObject playerObject, GameObjectList gameObjectList)
    {
        this.playerObject = playerObject;
        this.gameObjectList = gameObjectList;
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
/*
    public void DisplayInventoryActionMenu()
    {
       
    }
*/
    /*public void DisplayInteractActionMenu() ///External Item Interactions
    {
        Console.WriteLine("What would you like to interact with")
    }
    */


    public void DisplayMoveActionMenu()
    {
        while (true)
        {
            List<(GameObject, string)> adjacentRoomsWithDirections = gameObjectList.GetRoomObjectsAndCompassDirectionsAtAdjacentLocations(playerObject);

            Console.WriteLine("Where would you like to move?\n");

            int i = 0;
            foreach ((GameObject room, string direction) in adjacentRoomsWithDirections)
            {
                Console.WriteLine($"{i}:{room.GetName()} - {direction}");
                i++;
            }

            Console.WriteLine($"{i}: Back");
            int playerinput0 = GetPlayerInput();
            if (playerinput0 >= 0 && playerinput0 < i)
            {
                LocationComponent selectedLocation = adjacentRoomsWithDirections[playerinput0].Item1.GetObjectLocationComponent();
                playerObject.GetObjectLocationComponent().SetXLocation(selectedLocation.GetXLocation());
                playerObject.GetObjectLocationComponent().SetYLocation(selectedLocation.GetYLocation());
                break;            
            }
            

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


