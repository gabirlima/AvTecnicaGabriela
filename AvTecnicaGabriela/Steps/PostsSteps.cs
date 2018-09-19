using AvTecnicaGabriela.Endpoints;
using NUnit.Framework;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace AvTecnicaGabriela.Steps
{
    [Binding]
    public class PostsSteps
    {
        public PostEndpoint post;
        public int postId;

        public PostsSteps(PostEndpoint post)
        {
            this.post = post;
        }

        
        [Given(@"I registered a post")]
        [When(@"I send a request to register a post")]
        public void GivenIRegisteredAPost()
        {
            postId = post.RegistryPost();
        }
        
        [When(@"I send a request to search all posts")]
        public void WhenISendARequestToSearchAllPosts()
        {
            post.SearchPosts();
        }
        
        [When(@"I send a request to search post with id (.*)")]
        public void WhenISendARequestToSearchPostWithId(int id)
        {
            post.SearchPosts(id, "postid");
        }
        
        [When(@"I send a request to search post with user id (.*)")]
        public void WhenISendARequestToSearchPostWithUserId(int id)
        {
            post.SearchPosts(id, "userid");
        }
        
        [When(@"I send a request to update post with id (.*)")]
        public void WhenISendARequestToUpdateThePost(int postId)
        {
            post.UpdatePost(postId);
        }
        
        [When(@"I send a request to delete post with id (.*)")]
        public void WhenISendARequestToDeleteThePost(int postId)
        {
            post.DeletePost(postId);
        }
        
        [When(@"I send a request to update post with invalid id")]
        public void WhenISendARequestToUpdatePostWithInvalidId()
        {
            post.UpdatePost(0);
        }
        
        [When(@"I send a request to delete post with invalid id")]
        public void WhenISendARequestToDeletePostWithInvalidId()
        {
            post.DeletePost(0);
        }
        
        [Then(@"returned JSON objects is not null")]
        public void ThenReturnedJSONObjectsIsNotNull()
        {
            Assert.IsTrue(post.CheckResponseJSON());
        }
        
        [Then(@"returned (.*) request status")]
        public void ThenReturnedRequestStatus(int status)
        {
            switch(status)
            {
                case 200:
                    Assert.AreEqual(HttpStatusCode.OK, post.CheckResponseStatus());
                    break;
                case 404:
                    Assert.AreEqual(HttpStatusCode.NotFound, post.CheckResponseStatus());
                    break;
                case 201:
                    Assert.AreEqual(HttpStatusCode.Created, post.CheckResponseStatus());
                    break;
                default:
                    Assert.Inconclusive("Status informado não foi mapeado.");
                    break;
            }
            
        }
        
        [Then(@"the post was updated")]
        public void ThenThePostWasUpdated()
        {
            Assert.IsTrue(post.CheckUpdatedPost(postId));
        }
        
        [Then(@"the post was deleted")]
        public void ThenThePostWasDeleted()
        {
            Assert.IsFalse(post.SearchPosts(postId));
        }
    }
}
