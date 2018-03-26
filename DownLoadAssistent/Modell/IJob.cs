using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownLoadAssistent.Modell
{
    public enum JobStatus_e
    {
        IDLE,
        RUNNING,
        PAUSED,
        FINISHED,
        ERROR,
        STOPPED
    };

    public abstract class IJob
    {
        public JobStatus_e m_JobStatus;
        public int JobProgress { get; set; }

        public abstract int GetProgress();
        public abstract JobStatus_e GetStatus();
        public abstract void Start();
        public abstract void Stop();
        public abstract void Pause();
    }
}
