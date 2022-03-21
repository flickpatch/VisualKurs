using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VisualKurs.Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string secName { get; set; }
        [DataMember]
        public DateTime birthDate { get; set; }
        [DataMember]
        public List<Product> products { get; set; }
        public string email { get; set; }
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public string pass { get; set; }
        [DataMember]
        public byte[] photo { get; set; }
        public User()
        {
            products = new List<Product>();
        }
    }
}
