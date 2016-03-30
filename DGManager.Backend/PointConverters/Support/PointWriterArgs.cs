using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DGManager.Backend
{
    public class PointWriterArgs
    {
        private LogHandler _log;
        private ProgressHandler _progress;
        public string Filename;
        public Collection<PointOfInterestList> Tracks;
        public List<Jpeg> Photos;
        /// <summary>
        /// Used internally to output HTML for hooking up to google map events
        /// </summary>
        public bool IncludeGMapEvents;

        public PointWriterArgs()
        {
        }

        public PointWriterArgs(string filename, Collection<PointOfInterestList> tracks)
        {
            Filename = filename;
            Tracks = tracks;
        }

        public PointWriterArgs(string filename, Collection<PointOfInterestList> tracks, LogHandler log, ProgressHandler progress)
            : this(filename, tracks)
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
