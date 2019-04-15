using System;
using NUnit.Framework;
using TmobileTask.Utilities;

namespace TmobileTask.BaseFramework
{
    [SetUpFixture]
    public class BaseTest : Driver
    {
        [OneTimeSetUp]
        public static void OneSetUp()
        {
            Reports.StartReport();
        }

        [OneTimeTearDown]
        public static void OneTearDown()
        {
            Reports.EndReport();
        }

        [SetUp]
        public static void SetUp()
        {
            Reports.CreateTest();
            StartBrowser();
        }

        [TearDown]
        public static void TearDown()
        {
            Reports.LogTestResults();
            StopBrowser();
        }

    }
}
