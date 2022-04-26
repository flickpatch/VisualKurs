using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualKurs.Actions.Info;

namespace VisualKurs.Entities
{
   public  class Product
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
        public bool IsUser
        {
            get
            {
                if (user.id == AutorizeUser.user.id)
                  return true;                
                return false;
            }
        }
        public string Your { get
            {
                if (IsUser)
                    return "Ваш продукт";
                else 
                    return null;
            } }
       
    }
}
