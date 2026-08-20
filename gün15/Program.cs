using System;
using System.Collections.Generic;
using System.Linq;

namespace Gun15
{
    internal class Program
    {
        List<Games> games = new List<Games>();

        Dictionary<int, Types> gameDictionary =
            new Dictionary<int, Types>();


        // ---------------- GAME ----------------

        public void AddGame(int id, string name, decimal price)
        {
            if (games.Any(g => g.id == id))
            {
                throw new ArgumentException(
                    "Game with the same Id already exists."
                );
            }

            games.Add(new Games(id, name, price));
        }


        // ---------------- TYPE ----------------

        public void AddType(int id, string name)
        {
            if (gameDictionary.ContainsKey(id))
            {
                throw new ArgumentException(
                    "Type with the same Id already exists."
                );
            }

            gameDictionary.Add(id, new Types(id, name));
        }


        // ---------------- GAME CLASS ----------------

        public class Games
        {
            private int Id;
            private string Name;
            private decimal Price;

            public int id
            {
                get
                {
                    return Id;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException(
                            "Id cannot be negative."
                        );
                    }

                    Id = value;
                }
            }

            public string name
            {
                get
                {
                    return Name;
                }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException(
                            "Name cannot be empty."
                        );
                    }

                    Name = value;
                }
            }

            public decimal price
            {
                get
                {
                    return Price;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException(
                            "Price cannot be negative."
                        );
                    }

                    Price = value;
                }
            }

            public Games(int id, string name, decimal price)
            {
                this.id = id;
                this.name = name;
                this.price = price;
            }
        }


        // ---------------- TYPE CLASS ----------------

        public class Types
        {
            private int Id;
            private string TypeName;

            public int id
            {
                get
                {
                    return Id;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException(
                            "Id cannot be negative."
                        );
                    }

                    Id = value;
                }
            }

            public string name
            {
                get
                {
                    return TypeName;
                }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException(
                            "Name cannot be empty."
                        );
                    }

                    TypeName = value;
                }
            }

            public Types(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }


        // ---------------- MAIN ----------------

        static void Main(string[] args)
        {
            Program program = new Program();


            // GAME ADD

            Console.Write("How many games do you want to add: ");
            int numberOfGames = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfGames; i++)
            {
                Console.WriteLine($"\nGame {i + 1}");

                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                program.AddGame(id, name, price);
            }

            Console.WriteLine("\nGames added successfully!");


            // TYPE ADD

            Console.Write("\nHow many types do you want to add: ");
            int numberOfTypes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTypes; i++)
            {
                Console.WriteLine($"\nType {i + 1}");

                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                program.AddType(id, name);
            }

            Console.WriteLine("\nTypes added successfully!");

            Console.ReadLine();
        }
    }
}