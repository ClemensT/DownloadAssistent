using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownLoadAssistent.Modell
{
    public class JobManager
    {
        private Thread JobWorker;

        private Queue<IJob> JobList;
        private AutoResetEvent waitForSomethingTodo;

        public JobManager()
        {
            ThreadStart JobWorkerDelegate = new ThreadStart(ProcessJobs);
            JobWorker = new Thread(JobWorkerDelegate);
            JobList = new Queue<IJob>();
            waitForSomethingTodo = new AutoResetEvent(false);
            JobWorker.Start();
            
        }
        

        public void AddJob(IJob job)
        {
            JobList.Enqueue(job);
            waitForSomethingTodo.Set();
        }

        public void RemoveJob(IJob job)
        {

        }

        public void ProcessJobs()
        {
            while(true)
            {
                while(JobList.Count != 0)
                {
                    IJob jobToProcess = JobList.Dequeue();
                    jobToProcess.Start();
                }

                waitForSomethingTodo.WaitOne();
            }
        }
               


    }
}
