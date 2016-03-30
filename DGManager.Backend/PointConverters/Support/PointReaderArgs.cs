using System;

namespace DGManager.Backend
{
    public class PointReaderArgs
    {
        private LogHandler _log;
        private ProgressHandler _progress;
        public string[] Filenames;

        public PointReaderArgs() { }

        public PointReaderArgs(string[] filenames)
        {
            Filenames = filenames;
        }

        public PointReaderArgs(string[] filenames, LogHandler log, ProgressHandler progress)
            : this(filenames)
        {
            _log = log;
            _progress = progress;
        }

        public void Log(string msg)
        {
            if (_log != null)
                _log(msg);
        }

        public void ReportProgress(int progress)
        {
            if (_progress != null)
                _progress(progress);
        }
    }
}
