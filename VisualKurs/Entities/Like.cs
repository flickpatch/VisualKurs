using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualKurs.Entities
{
    public class Like
    {
        public int id { get; set; }
        public bool IsLiked { get; set; }
        public int UserID { get; set; }
        public int ProductId { get; set; }
        public virtual User user { get; set; }
        public virtual Product product { get; set; }

    }
}
