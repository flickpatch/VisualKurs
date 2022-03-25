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
        public static List<Product> getProducts()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Product");
            request.Method = "get";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + AutorizeUser.user.access_token);
            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(reader.ReadToEnd());
            return products;
        }
        public static void AddProduct(Product product)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/Product/" + product + "?id=" + AutorizeUser.user.id);
            request.Method = "get";
            request.ContentType = "application/json";
            string json = JsonSerializer.Serialize(product);
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();
            HttpWebResponse res = request.GetResponse() as HttpWebResponse;
            Console.WriteLine(res.StatusCode);
        }
    }
}
