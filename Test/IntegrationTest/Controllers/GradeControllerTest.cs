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
    public class GradeControllerTest:EnvironmentTest
    {
        private string Uri = "api/grade";

        [TestMethod]
        public async Task GetListGradeSucessfully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        
        [TestMethod]
        public async Task PostInsertGradeuccessFully()
        {
            //Arrange
            Grade grade=new Grade();
            grade.name = "EXCESO";
            grade.description = "COD 1 SITUACION A";
            grade.boolDelete = 0;
            var body = JsonConvert.SerializeObject(grade);
            //Act
            var response = await _client.PostAsync(Uri + "/insert",
                new StringContent(body, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(int.Parse(content.Result)>=1);
        }
        
        [TestMethod]
        public async Task GetByIdGradeSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri+"/1"); //carefully with ID
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        
        [TestMethod]
        public async Task PutModGradeSuccessFully()
        {
            //Arrange
            Grade grade=new Grade();
            grade.id = 2;
            grade.name = "Normal";
            grade.description = "Controlado";
            grade.boolDelete = 0;
            var body = JsonConvert.SerializeObject(grade);
            
            //Act
            var response = await _client.PutAsync(Uri + "/update",
                new StringContent(body, Encoding.UTF8, "application/json"));

            //var content = response.Content.ReadAsStringAsync();
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task DeleteGradeSuccessFully()
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