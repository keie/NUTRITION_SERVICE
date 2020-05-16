

using System.Text;
using ApiModel;
using Newtonsoft.Json;

namespace Test.IntegrationTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.AspNetCore.TestHost;
    using System.Net.Http;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using ApiCore;


    [TestClass]
    public class UserControllerTest:EnvironmentTest
    {
       
        private string Uri = "api/User";

       
        

        [TestMethod]
        public async Task GetResponseMethodGetListShouldBeFull()
        {
            //Arrange
            var response = await _client.GetAsync(Uri);
            var content = response.Content.ReadAsStringAsync();
            //Act
            //Assert 
            Assert.IsTrue((content.Result.Length >= 100));
            //FluentAssertion
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [TestMethod]
        public async Task GetEncryptSuccessfully()
        {
            //Arrange
            var valueExpected = "3C9909AFEC25354D551DAE21590BB2" +
                                "6E38D53F2173B8D3DC3EE" +
                                "E4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C" +
                                "9C36214DC9F14A42FD7A2FDB8485" +
                                 "6BCA5C44C2";
            User user=new User();
            user.password = "123";
            var body = JsonConvert.SerializeObject(user);
            //Act
            var response = await _client.PostAsync(Uri+"/encrypt",
                new StringContent(body, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync();
            //Assert
            //FluentAssertion
            content.Result.Should().Be(valueExpected);
        }
    }
}