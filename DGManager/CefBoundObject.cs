using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGManager
{
    public class CefBoundObject
    {
        public event EventHandler<LatLngEventArgs> MapRightClick;
        public void OnRightClick(double lat, double lng)
        {
            if (MapRightClick != null)
                MapRightClick(this, new LatLngEventArgs { Lat = lat, Lng = lng });
        }
        public event EventHandler<TrackEventArgs> TrackClick;
        public void OnTrackClick(string name, string start)
        {
            if (TrackClick != null)
                TrackClick(this, new TrackEventArgs { TrackName = name, Start = DateTime.Parse(start) });
        }

        //public void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        //{
        //    if (e.Frame.IsMain)
        //    {
        //        ((ChromiumWebBrowser)sender).ExecuteScriptAsync(@"
        //            document.body.onmouseup = function()
        //            {
        //                bound.onSelected(window.getSelection().toString());
        //            }
        //        ");
        //    }
        //}

        //public void OnRightClick(double lat, double lng)
        //{
        //    MessageBox.Show(String.Format("lat: {0}, lng: {1}", lat, lng));
        //}

        //public void OnSelected(string selected)
        //{

        //}
    }

    public class LatLngEventArgs : EventArgs
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class TrackEventArgs : EventArgs
    {
        public string TrackName { get; set; }
        public DateTime Start { get; set; }
    }
}
