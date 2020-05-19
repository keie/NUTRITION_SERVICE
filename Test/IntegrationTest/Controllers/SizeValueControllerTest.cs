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
    public class SizeValueControllerTest:EnvironmentTest
    {
        private string Uri = "api/sizevalue";
        
        [TestMethod]
        public async Task GetListSizeValueSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        
        [TestMethod]
        public async Task GetByIdSizeValueSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri+"/1"); //carefully with ID
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        
        [TestMethod]
        public async Task PostInsertSizeValueSuccessFully()
        {
            //Arrange
           
            SizeValue sizeValue=new SizeValue();
            sizeValue.firstValue = 0.12F;
            sizeValue.secondValue  = 1.14F;
            sizeValue.boolDelete = 0;
            
            var body = JsonConvert.SerializeObject(sizeValue);
            
            //Act
            var response = await _client.PostAsync(Uri + "/insert",
                new StringContent(body, Encoding.UTF8, "application/json"));

            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(int.Parse(content.Result)>=1);
        }
        
        [TestMethod]
        public async Task PutModSizeValueSuccessFully()
        {
            //Arrange
           
            SizeValue sizeValue=new SizeValue();
            sizeValue.id = 1;
            sizeValue.firstValue = 0.12F;
            sizeValue.secondValue  = 1.14F;
            sizeValue.boolDelete = 0;
            var body = JsonConvert.SerializeObject(sizeValue);
            
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
            var response = await _client.DeleteAsync(Uri + "/delete/1"); //carefully with ID

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}