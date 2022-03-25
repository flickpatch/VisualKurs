using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualKurs.Entities
{
    public class Photo
    {
        public int id { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }
        public byte[] image { get; set; }
    }
}
