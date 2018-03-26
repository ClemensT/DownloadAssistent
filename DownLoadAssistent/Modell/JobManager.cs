using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownLoadAssistent.Modell
{
    public class JobManager
    {
        private Thread JobWorker;

        public ObservableCollection<Queue<IJob>> JobListVM { get; set; }
        public Queue<IJob> JobList { get; set; }
        public Queue<IJob> JobListFinished { get; set; }
        private AutoResetEvent waitForSomethingTodo;

        public JobManager()
        {
            //ThreadStart JobWorkerDelegate = new ThreadStart(ProcessJobs);
            //JobWorker = new Thread(JobWorkerDelegate);
            JobList = new Queue<IJob>();
            JobListFinished = new Queue<IJob>();
            waitForSomethingTodo = new AutoResetEvent(false);
            //JobWorker.Start();
            JobListVM = new ObservableCollection<Queue<IJob>>();
            JobListVM.Add(JobList);
            JobListVM.Add(JobListFinished);
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
                while (JobList.Count != 0)
                {
                    IJob jobToProcess = JobList.Dequeue();
                    jobToProcess.Start();
                    JobListFinished.Enqueue(jobToProcess);
               }

                waitForSomethingTodo.WaitOne();
            }
        }
               


    }
}
