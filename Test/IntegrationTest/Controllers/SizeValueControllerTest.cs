using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}