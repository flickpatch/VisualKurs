using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualKurs.Entities
{
    public class User
    {       
        public int id { get; set; }
        public string name { get; set; }
        public string secName { get; set; }
        public DateTime birthDate { get; set; }
        public List<Product> products { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public byte[] photo { get; set; }
        public User()
        {
            products = new List<Product>();
        }
    }
}
