using Microsoft.VisualStudio.TestTools.UnitTesting;
using DownLoadAssistent.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownLoadAssistent.Modell.Tests
{
    [TestClass()]
    public class JobManagerTests
    {
        [TestMethod()]
        public void JobManagerTest()
        {
            bool success = true;

            JobManager manager = new JobManager();

            manager.AddJob(new DemoJob("a"));
            manager.AddJob(new DemoJob("b"));
            manager.AddJob(new DemoJob("c"));
            manager.AddJob(new DemoJob("d"));
            manager.AddJob(new DemoJob("e"));

            manager.ProcessJobs();

            Assert.IsTrue(success);
        }

        
    }
}