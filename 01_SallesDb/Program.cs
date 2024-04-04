using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace _01_SallesDb
{
    internal class Program
    {
        public static void ShowInfo(string cmd,SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(cmd, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),17}");
            }
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],17} ");
                }
                Console.WriteLine();
            }

            reader.Close();
        }
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = LEGION5\SQLEXPRESS;
                                        Initial Catalog = SportShop;
                                        Integrated Security = true;Connect Timeout = 2";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connected success!!!!");

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int key;
            string cmd = "";
            do
            {
                Console.Write("[1] - Info about clients\n[2] - Info about employees\n[3] - Info about sells certain employee\n" +
               "[4] - Info about sells on certain summ\n[5] - Most expensive and the cheapest buy\n[6] - First sale\nChoose : ");
                key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        cmd = @"select * from Clients";
                        ShowInfo(cmd, sqlConnection);
                        break;
                    case 2:
                        cmd = @"select * from Employees";
                        ShowInfo(cmd, sqlConnection);
                        break;
                    case 3:
                        //Ярощук Іван Петрович
                        //Михальчук Руслана Романівна
                        //Левчук Тетяна Степанівна
                        //Волос Ігор Іванович
                        Console.Write("Enter fullname : ");
                        string fullname = Console.ReadLine();
                        cmd = @"select *
                                from Salles
                                where EmployeeId = (select e.Id
					                                from Employees as e
					                                where EmployeeId = e.Id and e.FullName = " + @"'" + fullname + @"')";
                        ShowInfo(cmd, sqlConnection);
                        break;
                        case 4:
                        Console.Write("Enter summa : ");
                        fullname = Console.ReadLine();
                        cmd = @"select *
                                from Salles
                                where Price > " + fullname;
                        ShowInfo(cmd, sqlConnection);
                        break;
                        case 5:
                        Console.Write("Enter fullname : ");
                        fullname = Console.ReadLine();
                        cmd = @"select Max(s.Price) as 'Most expensive',Min(s.Price) as 'The cheapest'
                                from Salles as s
                                where EmployeeId = (select e.Id
					                                from Employees as e
					                                where EmployeeId = e.Id and e.FullName = " + @"'" + fullname + @"')";
                        ShowInfo(cmd, sqlConnection);
                        break;
                        case 6:
                        Console.Write("Enter fullname : ");
                        fullname = Console.ReadLine();
                        cmd = @"select top 1 e.FullName, s.Price
                                from Salles as s join Employees as e on s.EmployeeId = e.Id
                                where e.FullName = " + @"'" + fullname + @"'";
                        ShowInfo(cmd, sqlConnection);
                        break;
                    default:
                        break;
                }
            } while (key != 0);
           
            
        }
    }
}
