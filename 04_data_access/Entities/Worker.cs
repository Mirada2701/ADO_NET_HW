using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Shop_CourseWork_.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
