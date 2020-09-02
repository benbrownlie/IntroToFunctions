using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        //Default Player and Figure stats
        float _playerHealth = 100.0f;
        int _playerDamage = 10;
        float _figureHealth = 50.0f;
        int _figureDamage = 10;
        //
        bool _gameOver = false;
        string _playerName = "the employee";
        void RequestName(ref string name)
        {
            char input = ' ';
            //Loop until valid input is given
            while (input != '1')
            {
                //Clear previous text

                //Ask user for name
                Console.WriteLine("Enter a new name for " + _playerName);
                name = Console.ReadLine();
                //Give the user the option to change their name
                input = GetInput("Yes", "No", "Are you sure that's your name " + name + "?");
                //Displays disappointed message over player's poor choice of name
                if (input == '2')
                {
                    Console.WriteLine("Yeah, that's a terrible name. PLEASE try again");
                }
            }
        }

        void Explore()
        {
            char input = ' ';
            input = GetInput("Go left", "Go right", "You came to an intersection in the aisles");
            if (input == '1')
            {
                Console.WriteLine("You decide to go left. You are greeted by the Figure");
            }
            else if (input == '2')
            {
                Console.WriteLine("You walk down the aisle safely");
                Console.WriteLine("\nYou make it to a clearing in the aisles," +
               " shelves stocked with inventory surround the area");
                Console.WriteLine("Ahead of you is an exit, you run for it");
                Console.WriteLine("The sliding doors open to reveal the Figure is blocking your path");
            }
            Console.WriteLine("\nThe Figure attacks you");
            _gameOver = Combat(ref _playerHealth, ref _figureHealth);
        }
        void EnterRoom( int aisleNumber)
        {
            string exitMessage = "";
            switch (aisleNumber)
            {
                case 0:
                    {
                        exitMessage = "You turn around and return to the previous aisle";
                        Console.WriteLine("You're at the start of a new series of aisles");
                        break;
                    }
                case 1:
                    {
                        exitMessage = "You exit the canned-goods aisle";
                        Console.WriteLine("You walk forward and find yourself in the canned-goods aisle. Canned meats, vegetables, fruits and more sit well stocked on the shelves.");
                        break;
                    }
                case 2:
                    {
                        exitMessage = "You return to the canned-goods aisle";
                        Console.WriteLine("You walk forward once more and find yourself in the candy aisle");
                        break;
                    }
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    {
                        exitMessage = "You return to the candy aisle";
                        Console.WriteLine("You continue on walking through a awdwd7mv number of aisles");
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("\nAfter wandering for an unknown amount of hours you see a masked Figure blocking your path");
                        Console.WriteLine("He begins to approach you brandishing a kitchen knife");
                        Combat(ref _playerHealth, ref _figureHealth);

                        break;
                    }
            }
            Console.WriteLine("You are in Aisle: " + aisleNumber);
            char input = ' ';
            input = GetInput("Go Forward", "Go Back", "Where are you going?");
            if (input == '1')
            {
                EnterRoom(aisleNumber + 1);
            }

            Console.WriteLine(exitMessage);
        }

        bool Combat(ref float playerHealth, ref float figureHealth)
        {
            //initialize the input variable
            char input = ' ';
            //Create battle loop. Loops until enemy or player is dead
            while (playerHealth > 0 && figureHealth > 0)
            {
                //Get input from player
                input = GetInput("Attack", "Defend", "Run");
                //Attack option. Deals and takes damage.
                if (input == '1')
                {
                    figureHealth -= _playerDamage;
                    Console.WriteLine("You attacked and dealt 10 damage");
                }
                //Defend option. Takes no damage and deals no damage.
                else if (input == '2')
                {
                    Console.WriteLine("You blocked the figure's attack");
                    Console.ReadKey();
                    continue;
                }
                playerHealth -= _figureDamage;
                Console.WriteLine("The figure attacked and dealt " + _figureDamage + "");
                Console.ReadKey();
            }
            return playerHealth <= 0;
        }

        void ViewStats()
        {
            //Prints player stats to the screen
            Console.WriteLine("Employee ID");
            Console.WriteLine("Name: " + _playerName + "");
            Console.WriteLine("Health: " + _playerHealth + "");
            Console.WriteLine("Damage: " + _playerDamage + "");
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadKey();
        }

        char GetInput(string option1, string option2, string query)
        {
            //Initialize input value
            char input = ' ';
            //Loop until a valid input is recieved
            while (input != '1' && input != '2')
            {
                Console.WriteLine(query);
                //Display options
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. View stats");
                Console.Write("> ");
                //Get input from user
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                //If the player input 3, call the view stats function
                if (input == '3')
                {
                    ViewStats();
                }
            }
            //return input recieved from user
            return input;
        }
        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        //Used for initializing variables
        //Also used for performing start up tasks that should only be done once
        public void Start()
        {
            Console.WriteLine("Welcome to YOUR shift!");

        }

        //Repeated until the game ends
        //Used for all game logic that will repeat
        public void Update()
        {
            EnterRoom(0);
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThanks for shopping!");
        }
    }
}
