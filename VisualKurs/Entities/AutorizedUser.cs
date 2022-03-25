using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualKurs.Entities
{
    public class AutorizedUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string access_token { get; set; }
    }
}
