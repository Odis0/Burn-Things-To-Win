/*
public class PlayerUI
{
    GameObject player;
    GameObjectList gameObjectList;
    public PlayerUI(GameObject player, GameObjectList gameObjectList)
    { 
        this.player = player; 
        this.gameObjectList = gameObjectList;
        DisplayUITopLevel();
    }
    

    public void DisplayPlayerRoomName(GameObject player)
    {
        Console.WriteLine(gameObjectList.GetObjectRoomFromObject(player).GetName());
    }

    public void DisplayUITopLevel()
    {
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerRoomName(player);
            Console.WriteLine();

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

        }

    }
        public int DisplayMainActionMenu()
        {
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("0: Move");
                int playerInput = GetPlayerInput();
                return playerInput;
            
        }

    public void DisplayMoveActionMenu()
    {
        while (true)
        {
            List<List<GameObject>> listOfAdjacentLocationLists = world.GetLocationListsAdjacentFromObject(player);
            List<List<GameObject>> nonNullLists = new List<List<GameObject>>();

            Console.WriteLine("Where would you like to move?\n");

            int i = 0;
            foreach (List<GameObject> selectedList in listOfAdjacentLocationLists)
            {
                if (selectedList.Count > 0 && selectedList[0] != null)
                {
                    Console.WriteLine($"{i}:{selectedList[0].GetName()}");
                    nonNullLists.Add(selectedList); // Add non-null lists to a new list
                    i++;
                }
            }

            Console.WriteLine($"{i}: Back");
            int playerInput = GetPlayerInput();
            if (playerInput >= 0 && playerInput < i)
            {
                world.MoveObjectBetweenWorldArrayLists(player, nonNullLists[playerInput]);
                break;
            }
            else if (playerInput == i)
            {
                break;
            }
            else
            {
                Console.WriteLine("You can't move there.");
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
*/