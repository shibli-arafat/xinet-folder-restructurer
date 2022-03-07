using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class DemoApiTests
    {
        private readonly Mock<IDemoBo> _demoBo = new Mock<IDemoBo>();
        private readonly DemoApi _demoApi;

        public DemoApiTests()
        {
            _demoApi = new DemoApi(_demoBo.Object);
        }

        [TestMethod()]
        public void CreateDemoTest()
        {
            _demoBo.Setup(x => x.CreateDemo(0));
            _demoApi.CreateDemo(0, 1);
            //Mock.VerifyAll();
            _demoBo.Verify();
            //Assert.Fail();
        }
    }
}