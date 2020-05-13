using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiModel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit.Sdk;

namespace Test.IntegrationTest
{
    [TestClass]
    public class PersonalReferenceControllerTest:EnvironmentTest
    {
        private string Uri = "api/personalReference";

        [TestMethod]
        public async Task GetPersonalReferenceListSuccessfully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        [TestMethod]
        public async Task GetPersonalReferenceByIdSuccessfully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri+"/3");
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        [TestMethod]
        public async Task PostInsertPersonPersonalReferenceSuccessFully()
        {
            //Arrange
           
            PersonalReference pr=new PersonalReference();
            pr.age = 10;
            pr.gender = 'T';
            pr.smallerThan = 0;
            pr.greaterThan = 1;
            var body = JsonConvert.SerializeObject(pr);
            
            //Act
            var response = await _client.PostAsync(Uri + "/insert",
                new StringContent(body, Encoding.UTF8, "application/json"));

            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(int.Parse(content.Result)>=1);
        }
        
        [TestMethod]
        public async Task PutModPersonPersonalReferenceSuccessFully()
        {
            //Arrange
           
            PersonalReference pr=new PersonalReference();
            pr.id = 3;
            pr.age = 10;
            pr.gender = 'X';
            pr.smallerThan = 0;
            pr.greaterThan = 1;
            pr.boolDelete = 0;
            var body = JsonConvert.SerializeObject(pr);
            
            //Act
            var response = await _client.PutAsync(Uri + "/update",
                new StringContent(body, Encoding.UTF8, "application/json"));

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [TestMethod]
        public async Task DeleteLogicPersonPersonalReferenceSuccessFully()
        {
            //Arrange
            //Act
            var response = await _client.DeleteAsync(Uri + "/delete/4");

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
    }
}