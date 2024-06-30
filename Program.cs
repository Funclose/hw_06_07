
namespace hw_06_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CollectionPoem poems = new CollectionPoem();
            poems.AddPoems(new Poem("Raven", "Edgar ", 1845, "Once", "Horror"));
            poems.AddPoems(new Poem("Ode ", "Percy ", 1820, "breath", "Romantic"));


            poems.SaveToFile("poems.json");


            poems.LoadFromFile("poems.json");

            string titleToFind = "Raven";
            Poem foundPoem = poems.FindByTitle(titleToFind);
            if (foundPoem != null)
            {
                Console.WriteLine($"\nFound poem by title '{titleToFind}':");
                Console.WriteLine(foundPoem);
            }
            else
            {
                Console.WriteLine($"\nPoem with title '{titleToFind}' not found.");
            }

            poems.UpdateTitle("Raven", "hello");
            
            poems.Show();

            
            
        }
    }
}
