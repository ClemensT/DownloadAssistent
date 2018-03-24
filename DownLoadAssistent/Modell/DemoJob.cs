using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownLoadAssistent.Modell
{
    public class DemoJob : IJob
    {
        String m_content;
        int progress;

        public DemoJob(String Content )
        {
            m_content = Content;
            progress = 100;
        }

        public override JobProgress_e GetProgress()
        {
            return this.m_JobProgress;
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            while(progress-- > 0)
            {
                this.m_JobProgress = JobProgress_e.RUNNING;
                Console.Write(m_content);
            }
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
