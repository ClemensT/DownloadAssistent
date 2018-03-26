using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownLoadAssistent.Modell
{
    public class DemoJob : IJob
    {
        String m_content;

        public DemoJob(String Content)
        {
            m_content = Content;
            JobProgress = 0;
        }

        public override JobStatus_e GetStatus()
        { 
            return JobStatus_e.IDLE;
        }

        public override int GetProgress()
        {
            return JobProgress;
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            while(JobProgress < 100)
            {
                this.m_JobStatus = JobStatus_e.RUNNING;
                System.Diagnostics.Debug.Print(m_content + " " + JobProgress);
                Thread.Sleep(1000);
                JobProgress++;
            }
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
