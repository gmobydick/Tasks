using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDO.Entities;

namespace TestTaskDO.Entities
{
    
    
    /// <summary>
    ///This is a test class for TaskTimeTest and is intended
    ///to contain all TaskTimeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TaskTimeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for WorkTime
        ///</summary>
        [TestMethod()]
        public void WorkTimeTest()
        {
            var target = new TaskTime
                             {
                                 WorkedFrom = DateTime.Parse("2011-07-01 12:00:00"),
                                 WorkedTo = DateTime.Parse("2011-07-01 12:45:00")
                             };

            double actual = target.WorkTime;
            
            Assert.AreEqual(0.75, actual, "Wrong WorkTime calculation!");
        }
    }
}
