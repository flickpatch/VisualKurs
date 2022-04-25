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

namespace VisualKurs.Actions.Requests.ProductRequests
{
    public class ProductRequest
    {   
        public static List<Product> GetProductsBySearxh(string search)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Product/search/" + search + "/" + AutorizeUser.user.id);
            req.Method = "get";
            req.ContentType = "application/json";
            req.Headers.Add("Authorization", "Bearer " + AutorizeUser.user.access_token);
            StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(reader.ReadToEnd());
            return products;
        }
        public static List<Product> getProducts()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Product/id/"+AutorizeUser.user.id);
            request.Method = "get";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + AutorizeUser.user.access_token);
            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(reader.ReadToEnd());
            return products;
        }
        public static HttpStatusCode AddProduct(Product product)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Product/" + product + "?id=" + AutorizeUser.user.id);
            request.Method = "post";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + AutorizeUser.user.access_token);
            string json = JsonSerializer.Serialize(product);
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();
            HttpWebResponse res = request.GetResponse() as HttpWebResponse;
            return res.StatusCode;
        }
        public static List<Product> getYourProducts(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Product/" + id);
            req.Method = "get";
            req.ContentType = "application/json";
            req.Headers.Add("Authorization", "Bearer " + AutorizeUser.user.access_token);
            StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(reader.ReadToEnd());
            return products;
        }
    }
}
