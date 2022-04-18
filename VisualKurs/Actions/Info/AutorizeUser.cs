using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VisualKurs.Entities;

namespace VisualKurs.Actions.Info
{
    public class AutorizeUser
    {
        public static AutorizedUser user { get; set; }
        public static bool AutorizatingUser(string pass, string login)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44327/token?login=" + login + "&pass=" + pass);
                request.Method = "post";
                request.ContentType = "application/json";
                StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
                user = JsonSerializer.Deserialize<AutorizedUser>(reader.ReadToEnd());
                return true;
            }
            catch(WebException ex)
            {
                if(ex.Status == WebExceptionStatus.UnknownError)
                {
                    return false;

                }
                return true;

            }
                
            
            
        }
    }
}
