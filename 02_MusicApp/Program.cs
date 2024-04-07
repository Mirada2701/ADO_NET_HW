namespace _02_MusicApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicAppDbContext context = new MusicAppDbContext();
            context.Countries.Add(new Country()
            {
                Name = "Ukraine"
            });
            context.Countries.Add(new Country()
            {
                Name = "Poland"
            });
            context.SaveChanges();

            foreach (var country in context.Countries)
            {
                Console.WriteLine(country.Name);
            }
        }
    }
}
