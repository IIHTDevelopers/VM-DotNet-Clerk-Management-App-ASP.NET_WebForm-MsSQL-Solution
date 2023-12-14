

using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClerkManagementApp.DAL.Interfaces;
using ClerkManagementApp.DAL.Services;
using Xunit;
using Xunit.Abstractions;

namespace ClerkManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IClerkService _clerkService;
        public readonly Mock<IClerkRepository> clerkservice = new Mock<IClerkRepository>();

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _clerkService = new ClerkService(clerkservice.Object);
            _output = output;
        }

        [Fact]
        public async Task<bool> Testfor_GetAll_Clerks_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                clerkservice.Setup(repos => repos.GetAll()).Returns("");
                var result = _clerkService.GetAll();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Clerks_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                clerkservice.Setup(repos => repos.Update()).Returns("");
                var result = _clerkService.Update();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}