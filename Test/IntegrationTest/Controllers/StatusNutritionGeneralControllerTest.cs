using System.Collections.Generic;
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
    public class StatusNutritionGeneralControllerTest:EnvironmentTest
    {
        private string Uri = "api/statusNutritionGeneral";

        [TestMethod]
        public async Task GetStatusNutritionGeneralListSuccessfully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }
        
        /*[TestMethod]
        public async Task GetValidationInsertStatusNutritionGeneralSuccessFully()
        {
            //Arrange
            var response = await _client.GetAsync(Uri+"/validateInsert/1/2/3"); //carefully with ID
            //Act
            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(content.Result.Length>=20);
        }*/
        
        [TestMethod]
        public async Task PostInsertStatusNutritionGeneralSuccessFully()
        {
            //Arrange
            StatusNutritionGeneral statusNutrition=new StatusNutritionGeneral();
            List<KgValue> kgValList=new List<KgValue>();
            List<PersonalReference> pReferenceList=new List<PersonalReference>();
            List<SizeValue> sizeValList=new List<SizeValue>();
            List<Grade> gradeList=new List<Grade>();
           /* statusNutrition.firstValue = 1.45F;
            statusNutrition.secondValue = 2.00F;*/
            statusNutrition.idPreference = 2;
            statusNutrition.idKgVal = 2;
            statusNutrition.idSizeVal = 2;
            statusNutrition.idGrade = 2;
            statusNutrition.boolDelete = 0;
            statusNutrition.kgValues = kgValList;
            statusNutrition.sizeValues = sizeValList;
            statusNutrition.pReferences = pReferenceList;
            statusNutrition.grades = gradeList;
            var body = JsonConvert.SerializeObject(statusNutrition);
            
            //Act
            var response = await _client.PostAsync(Uri + "/insert",
                new StringContent(body, Encoding.UTF8, "application/json"));

            var content = response.Content.ReadAsStringAsync();
            //Assert
            Assert.IsTrue(int.Parse(content.Result)>=1);
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
        public async Task DeleteStatusNutritionGeneralSuccessFully()
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