using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TmobileTask.Utilities
{
    public class Reports
    {
        protected static ExtentReports _extent;
        protected static ExtentTest _test;

        public static void StartReport()

        {
            //To obtain the current solution path/project path

            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;


            //Append the html report file to current project path

            string reportPath = projectPath + "Reports/";

            //Boolean value for replacing exisisting report
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

        }

        public static void EndReport()

        {
            _extent.Flush();

        }
        public static void CreateTest()

        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
        public static void LogTestResults()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }
    }
}
