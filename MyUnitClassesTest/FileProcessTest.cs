using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyUnitClasses;
using System.Configuration;
using System.IO;

namespace MyUnitClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\WrongFileName.Wrong";
        private string _GoodFileName;

        #region Class Initialize and Cleanup
        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In the Class Initialize.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            
        }
        #endregion

        #region Test Initialize and Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File: " + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Lovely World!");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting File: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion


        public TestContext TestContext { get; set; }

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("Rupom")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            //SetGoodFileName();
            //TestContext.WriteLine("Creating the file: " + _GoodFileName);
            //File.AppendAllText(_GoodFileName, "Lovely World!");
            TestContext.WriteLine("Testing the file: " + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            //File.Delete(_GoodFileName);
            //TestContext.WriteLine("Deleting the file: " + _GoodFileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does NOT exist.")]
        [Owner("Rupom")]
        [Priority(0)]
        [TestCategory("NoException")]
        [Ignore()]
        public void FileNameDoesExistSimnpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall,"File Does NOT Exist.");
        }

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("Rupom")]
        [Priority(0)]
        [TestCategory("NoException")]
        [Ignore()]
        public void FileNameDoesExistMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File '{0}' Does NOT Exist.",_GoodFileName);
        }

        [TestMethod]
        [Description("Check to see if a file does NOT exist.")]
        [Owner("Rupom")]
        [Priority(0)]
        [TestCategory("NoException")]
        //[Ignore()]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("Ahsan")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        [Owner("Ahsan")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //The test was a success
                return;
            }

            Assert.Fail("Call to file FileExists did NOT thrw an ArgumentNUllException.");

        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        [Timeout(3000)]
        [Ignore()]
        public void SimulateTimeOut()
        {
            System.Threading.Thread.Sleep(4000);
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Rupom")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp= new FileProcess();

            string fileName;
            bool fromCall;

            fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
            TestContext.WriteLine("Checking file: " + fileName);

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

    }
}
