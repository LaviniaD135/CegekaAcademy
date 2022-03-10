
namespace Tema01_academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> obj = new Set<int>();
            try
            {
                obj.Insert(1);
                obj.Insert(2);
                obj.Insert(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"!!!!{ex.Message}!!!");
            }
            Console.WriteLine($"------Setul obj1 dupa adaugarea de elemente: ------");
            obj.Display();
            obj.Remove(2);
            Console.WriteLine($"------Setul obj1 dupa stergerea elementului 2------");
            obj.Display();
            Set<string> obj2 = new Set<string>();
            try
            {
                obj2.Insert("Ana");
                obj2.Insert("Banana");
                obj2.Insert("Lalala");
                obj2.Insert("Tralalala");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------{ex.Message}------");
            }

            Set<string> obj3 = new Set<string>();
            try
            {
                obj3.Insert("alabala");
                obj3.Insert("portocala");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            try
            {
                Console.WriteLine($"------Setul 2+ setul 3: ------");
                obj2.Merge(obj3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            obj2.Display();
            Console.WriteLine($"------Subset filtrat: ------");
            obj2.Filter(t => (t.ToString()).Contains("n"));

        }

    }
}
