using DownLoadAssistent.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownLoadAssistent
{
    class DownloadJob : IJob
    {
        protected DownloadJob()
        {

        }



        public override int GetProgress()
        {
            throw new NotImplementedException();
        }

        public override JobStatus_e GetStatus()
        {
            throw new NotImplementedException();
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
