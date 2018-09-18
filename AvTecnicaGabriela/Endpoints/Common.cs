using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AvTecnicaGabriela.Endpoints
{
    public class Common
    {
        public RestClient client;
        public RestRequest request;
        public static IRestResponse response;

        string url = ConfigurationSettings.AppSettings["URL"];

        public Boolean CheckAPI()
        {
            client = new RestClient(url + "/posts");
            request = new RestRequest(Method.GET);

            response = client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
