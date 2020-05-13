using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiModel;
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
        public async Task PostPersonPersonalReferenceSuccessFully()
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
        
    }
}