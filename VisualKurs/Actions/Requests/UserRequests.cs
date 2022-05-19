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
        public static HttpStatusCode RegistrUser(User u)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/");
            request.Method = "Post";
            request.ContentType = "application/json";
            string json = JsonSerializer.Serialize(u);
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return response.StatusCode;
        }
        public static User GetUserByProduct(int userid)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/" + userid);
            req.Method = "GET";
            req.ContentType = "application/json";
            StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
            User u = JsonSerializer.Deserialize<User>(reader.ReadToEnd());
            return u;
            
        }
        public static HttpStatusCode ChangeUser(User u)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/" + u);
            req.Method = "PUT";
            req.ContentType = "application/json";
            string json = JsonSerializer.Serialize(u);
            StreamWriter writer = new StreamWriter(req.GetRequestStream());
            writer.Write(json);
            writer.Close();
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            return response.StatusCode;
        }
        public static HttpStatusCode Like(int product)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/like/" + product + "/" + AutorizeUser.user.id);
            req.Method = "POST";
            req.ContentType = "application/json";         
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            return res.StatusCode;
        }
        public static List<Product> GetLikedProducts()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/likebyid/" + AutorizeUser.user.id);
            request.Method = "GET";
            request.ContentType = "application/json";
            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            return JsonSerializer.Deserialize<List<Product>>(reader.ReadToEnd()); 
        }
        public static bool IsLikedProduct(int productid)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/" + AutorizeUser.user.id + "/" + productid);
                request.Method = "get";
                request.ContentType = "application/json";
                StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
                Like like = JsonSerializer.Deserialize<Like>(reader.ReadToEnd());
                return true;         
            }
            catch(WebException ex)
            {
                if(ex.Status == WebExceptionStatus.UnknownError)
                return false;
            }            
                return false;
            
          


        }
        public static HttpStatusCode DeleteLike(int productid)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Users/" + AutorizeUser.user.id + "/" + productid);
            request.Method = "Delete";
            request.ContentType = "application/json";
            HttpWebResponse res = request.GetResponse() as HttpWebResponse;
            return res.StatusCode;
        }

      
    }
}
