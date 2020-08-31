using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        bool _gameOver = false;
        string _playerName = "";
        void RequestName()
        {
            //If player already has a name, return from function
            if(_playerName != "")
            {
                return;
            }
            char input = ' ';
            //Loop until valid input is given
            while (input != '1')
            {
                //Clear previous text
                
                //Ask user for name
                Console.WriteLine("Enter your name");
                _playerName = Console.ReadLine();
                //Display username
                Console.WriteLine("Welcome " + _playerName + " ");
                //Give the user the option to change their name
                input = GetInput("Yes", "No", "Are you sure that's your name " + _playerName + "?");
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
            if(input == '1')
            {
                Console.WriteLine("You decide to go left. You are greeted by the Figure");
                _gameOver = true;
            }
            else if(input == '2')
            {
                Console.WriteLine("You walk down the aisle safely");
                Console.WriteLine("\nYou make it to a clearing in the aisles," +
               " shelves stocked with inventory surround the area");
                Console.WriteLine("On display infront of you is: A set of cutlery and a splitting axe");
            }
           
        }
        void Combat()
        {
            //Used to store the player's stats
            float playerHealth = 50.0f;
            int playerDamage = 5;
            //Used to store the Figure's stats
            float figureHealth = 100.0f;
            int figureDamage = 10;
            //Used to store combat loop
            char input = ' ';
            input = GetInput("Fight", "Defend", "Run");
            if(input == '1')
            {
                Console.WriteLine("\nYou swing at the Figure");
                figureHealth -= playerDamage;
                playerHealth -= figureDamage;
                Console.WriteLine("You dealt " + playerDamage + "");
                Console.WriteLine("You took " + figureDamage + "");
            }
            else if(input == '2')
            {
                Console.WriteLine("\nYou raise your arms to block the incoming attack");
                playerHealth -= figureDamage - 10;
                Console.WriteLine("You blocked the attack and took 0 damage");
            }
            
        }

        void ViewStats()
        {
            //Prints player stats to the screen
            Console.WriteLine(_playerName);
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
                if(input == '3')
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
            RequestName();
            Explore();
            Combat();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThanks for shopping!");
        }
    }
}
