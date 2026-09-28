using System;
using System.Collections.Generic;
using System.Linq;

namespace Gun15
{
    public class Game
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int CategoryId { get; }
        public Game(int id, string name, decimal price, int categoryId)
        {
            if (id <= 0 || categoryId <= 0 || price < 0 || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid game details.");
            Id = id; Name = name; Price = price; CategoryId = categoryId;
        }
    }

    internal class Program
    {
        static void Main()
        {
            var categories = new Dictionary<int, string> { [1] = "Aksiyon", [2] = "Bulmaca" };
            var games = new List<Game>
            {
                new Game(1, "Ada", 50m, 1),
                new Game(2, "Kare", 30m, 2)
            };
            foreach (var game in games)
                Console.WriteLine($"{game.Name} - {categories[game.CategoryId]} - {game.Price:C}");
            Console.WriteLine($"Farklı kategori sayısı: {games.Select(g => g.CategoryId).Distinct().Count()}");
        }
    }
}
