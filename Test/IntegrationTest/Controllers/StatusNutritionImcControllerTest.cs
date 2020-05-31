using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ApiModel;
using FluentAssertions;

namespace Test.IntegrationTest
{
    [TestClass]
    public class StatusNutritionImcControllrTest:EnvironmentTest
    {
        private string Uri = "api/imc";
        
        [TestMethod]
        public async Task PostInsertStatusImcSuccessFully()
        {
            //Arrange
            StatusNutritionImc imc=new StatusNutritionImc();
            imc.firstRange = 13.2F;
            imc.secondRange = 15.00F;
            imc.boolDelete = 0;
            
            var body = JsonConvert.SerializeObject(imc);
            
            //Act
            var response = await _client.PostAsync(Uri + "/insert",
                new StringContent(body, Encoding.UTF8, "application/json"));

            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task GetListStatusImcSucessfully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        [TestMethod]
        public async Task GetByIdStatusIMcSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri+"/1"); //carefully with ID
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        [TestMethod]
        public async Task PutModStatusNUtritionImcSuccessFully()
        {
            //Arrange
            StatusNutritionImc imc=new StatusNutritionImc();
            imc.id = 1;
            imc.firstRange = 0.00F;
            imc.secondRange = 1.11F;
            imc.boolDelete = 0;
            var body = JsonConvert.SerializeObject(imc);
            
            //Act
            var response = await _client.PutAsync(Uri + "/update",
                new StringContent(body, Encoding.UTF8, "application/json"));

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task DeleteImcSuccessFully()
        {
            //Arrange
            //Act
            var response = await _client.DeleteAsync(Uri + "/delete/2"); //carefully with ID

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}