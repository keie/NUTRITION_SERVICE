using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Test.IntegrationTest
{
    [TestClass]
    public class AgeValueControllerTest:EnvironmentTest
    {
        private string Uri = "api/age";
        
        [TestMethod]
        public async Task PostInsertStatusAgeSuccessFully()
        {
            //Arrange
            AgeValue age=new AgeValue();
            age.firstValue = 13;
            age.secondValue = 15;
            age.boolDelete = 0;
            
            var body = JsonConvert.SerializeObject(age);
            
            //Act
            var response = await _client.PostAsync(Uri + "/insert",
                new StringContent(body, Encoding.UTF8, "application/json"));

            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task GetListAgeSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        [TestMethod]
        public async Task GetByIdAgeSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri+"/1"); //carefully with ID
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        [TestMethod]
        public async Task PutModAgeSuccessFully()
        {
            //Arrange
            AgeValue kgVal=new AgeValue();
            kgVal.id = 1;
            kgVal.firstValue = 1;
            kgVal.secondValue = 2;
            kgVal.boolDelete = 0;
            var body = JsonConvert.SerializeObject(kgVal);
            
            //Act
            var response = await _client.PutAsync(Uri + "/update",
                new StringContent(body, Encoding.UTF8, "application/json"));

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task DeleteAgeSuccessFully()
        {
            //Arrange
            //Act
            var response = await _client.DeleteAsync(Uri + "/delete/1"); //carefully with ID

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}