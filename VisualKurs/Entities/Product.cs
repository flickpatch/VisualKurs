using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualKurs.Entities
{
   public  class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateCreate { get; set; }
        public bool isActivity { get; set; }
        public List<Photo> photos { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public Product()
        {
            photos = new List<Photo>();
        }
    }
}
