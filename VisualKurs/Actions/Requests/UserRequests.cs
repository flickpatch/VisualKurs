using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VisualKurs.Actions.Info;
using VisualKurs.Entities;

namespace VisualKurs.Actions.Requests
{
    public class UserRequests
    { 
        public static void RegistrUser(User u)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/");
            request.Method = "Post";
            request.ContentType = "application/json";
            string json = JsonSerializer.Serialize(u);
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Console.WriteLine(response.StatusCode);
        }
      
    }
}
