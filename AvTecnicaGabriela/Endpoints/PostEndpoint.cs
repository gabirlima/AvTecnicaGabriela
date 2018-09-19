using AvTecnicaGabriela.JSONModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
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
    public class PostEndpoint
    {
        public RestClient client;
        public RestRequest request;
        public static IRestResponse response;

        string url = ConfigurationSettings.AppSettings["URL"];

        string titlePostUpdated = "Updated post title - gabriela lima";

        public int RegistryPost()
        {
            client = new RestClient(url + "/posts");
            request = new RestRequest(Method.POST);

            request.AddHeader("Content-type", "application/json; charset=UTF-8");

            PostModel newPost = new PostModel();
            newPost.Title = "new post - gabriela lima";
            newPost.UserId = 1;
            newPost.Body = "This is a new post registred by Gabriela Lima";

            request.AddParameter("undefined", newPost.ToJson(), ParameterType.RequestBody);

            response = client.Execute(request);
            var postModel = PostModel.FromJson(response.Content);

            return postModel.Id;
        }

        public void SearchPosts()
        {
            client = new RestClient(url + "/posts");
            request = new RestRequest(Method.GET);

            response = client.Execute(request);

            var searchResult = PostModelList.FromJson(response.Content);
        }

        public void SearchPosts(int id, string filter)
        {
            if(filter == "postid")
            {
                client = new RestClient(url + "/posts/" + id);
            }
            else
            {
                if(filter == "userid")
                {
                    client = new RestClient(url + "/posts?userId=" + id);
                }
                else
                {
                    Assert.Fail("Filtro inválido.");
                }
            }

            request = new RestRequest(Method.GET);

            response = client.Execute(request);
        }

        public Boolean SearchPosts(int id)
        {
            client = new RestClient(url + "/posts/" + id);
            request = new RestRequest(Method.GET);

            response = client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public void UpdatePost(int id)
        {
            client = new RestClient(url + "/posts/" + id);
            request = new RestRequest(Method.PATCH);

            request.AddHeader("Content-type", "application/json; charset=UTF-8");
            request.AddBody("title", "alterando título do post");

            response = client.Execute(request);
        }

        public void DeletePost(int id)
        {
            client = new RestClient(url + "/posts/" + id);
            request = new RestRequest(Method.DELETE);

            response = client.Execute(request);
        }

        public Boolean CheckResponseJSON()
        {
            return response.Content.Count() != 0;
        }

        public HttpStatusCode CheckResponseStatus()
        {
            return response.StatusCode;
        } 

        public Boolean CheckUpdatedPost(int postId)
        {
            client = new RestClient(url + "/posts/" + postId);
            request = new RestRequest("GET");

            response = client.Execute(request);
            var postModel = PostModel.FromJson(response.Content);

            return postModel.Title == titlePostUpdated;
        }
    }
}
