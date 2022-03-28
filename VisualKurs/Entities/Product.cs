using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualKurs.Entities
{
   public  class Product:INotifyPropertyChanged
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateCreate { get; set; }
        public bool isActivity { get; set; }
        public byte[] photo { get; set; }
        public int userId { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public virtual User user { get; set; }
      
       
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
