using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}