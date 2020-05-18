using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Test.IntegrationTest
{
    using System;
    using ApiModel;
    using Microsoft.AspNetCore.Mvc;
    using ApiBussinessLogic.Interfaces;
    
    [TestClass]
    public class KgValuesControllerTest:EnvironmentTest
    {
        private string Uri = "api/kgvalue";

        [TestMethod]
        public async Task GetListKgValuesSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        [TestMethod]
        public async Task PostInsertKgValuesSuccessFully()
        {
            //Arrange
            KgValue kgVal=new KgValue();
            kgVal.firstValue = 12.33F;
            kgVal.secondValue = 11.11F;
            var body = JsonConvert.SerializeObject(kgVal);
            //Act
            var response = await _client.PostAsync(Uri + "/insert",
                new StringContent(body, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(int.Parse(content.Result)>=1);
        }
        [TestMethod]
        public async Task GetByIdKgValuesSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri+"/1"); //carefully with ID
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        
        [TestMethod]
        public async Task PutModKgValuesSuccessFully()
        {
            //Arrange
            KgValue kgVal=new KgValue();
            kgVal.id = 2;
            kgVal.firstValue = 15.00F;
            kgVal.secondValue = 0.11F;
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
        public async Task DeleteKgValuesSuccessFully()
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