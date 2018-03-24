using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownLoadAssistent.Modell
{
    public enum JobProgress_e
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
        public JobProgress_e m_JobProgress;

        public abstract JobProgress_e GetProgress();
        public abstract void Start();
        public abstract void Stop();
        public abstract void Pause();
    }
}
