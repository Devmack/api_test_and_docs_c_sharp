using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwaggerShowcase;
using SwaggerShowcase.Models;
using Xunit;

namespace SwaggerShowcaseTests
{
    public class AnotherMentorEndpointTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AnotherMentorEndpointTests(WebApplicationFactory<Startup> _factory)
        {
            this._factory = _factory;
        }

        [Theory]
        [InlineData("/api/mentors")]
        [InlineData("/api/mentors/1")]
        public async Task TestGetMentorsReturnJsonContent(string url)
        {
            //Arrange 
            using var client = _factory.CreateClient();

            //Act 
            var response = await client.GetAsync(url);

            //Assert
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            
        }

        [Fact]
        public async Task TestIfGetAllMentorsReturnsOk()
        {
            //Arrange
            using var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/api/mentors");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestIfGetSingleMentorReturnsProperData()
        {
            //Arrange
            using var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/api/mentors/1");
            var singleMentor = await response.Content.ReadAsStringAsync();
            Mentor mentorDeserialized = JsonConvert.DeserializeObject<Mentor>(singleMentor);

            //Assert
            Assert.Equal("Dominik", mentorDeserialized.Name);
        }

        [Fact]
        public async Task TestIfGetAllMentorsReturnsAllMentors()
        {
            //Arrange
            using var client = _factory.CreateClient();
            var response = await client.GetStringAsync("/api/mentors");

            //Act
            List<Mentor> resultMentor = JsonConvert.DeserializeObject<List<Mentor>>(response); 

            //Assert
            Assert.Equal("Dominik", resultMentor[0].Name);
        }
    }
}
