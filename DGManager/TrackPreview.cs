using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
    public partial class TrackPreview : UserControl
    {
        private List<PointOfInterestList> _tracks = new List<PointOfInterestList>();
        private BoundingBox _bounds;
        private float zoom = 1;
        private int offsetX, offsetY, dragX, dragY;

        public float Zoom { get { return zoom; } set { zoom = value; label1.Text = String.Format("{0}x", Zoom); } }

        public int OffsetX { get { return offsetX; } set { offsetX = value; } }

        public int OffsetY { get { return offsetY; } set { offsetY = value; } }

        public TrackPreview()
        {
            InitializeComponent();
        }

        public void SetTracks(IEnumerable<PointOfInterestList> tracks)
        {
            _tracks.Clear();
            _tracks.AddRange(tracks);
                Invalidate();
                pictureBox1.Top = 0;
                pictureBox1.Left = 0;
                pictureBox1.Width = panel1.Width;
                pictureBox1.Height = panel1.Height;
            // 5/11/09 - Had to add this line back, not sure why I removed it.
                CalculateBounds();
                pictureBox1.Image = Render();
        }

        public void CalculateBounds()
        {
            if (_tracks != null)
            {
                PointOfInterestList firstList;
                firstList = _tracks[0];
                firstList.CalcBBox(true);

                for (int i = 1; i < _tracks.Count; i++)
                {
                    PointOfInterestList poiList = _tracks[i];
                    poiList.BBox.N = firstList.BBox.N;
                    poiList.BBox.S = firstList.BBox.S;
                    poiList.BBox.E = firstList.BBox.E;
                    poiList.BBox.W = firstList.BBox.W;
                    poiList.CalcBBox(false);
                    firstList = poiList;
                }
                _bounds = firstList.BBox;
                if (_bounds.N == _bounds.S)
                {
                    _bounds.N += .000001;
                    _bounds.S -= .000001;
                }
                if (_bounds.E == _bounds.W)
                {
                    _bounds.E += .000001;
                    _bounds.W += .000001;
                }
            }
        }

        private Image Render()
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bm);
            if (_tracks == null || _tracks.Count == 0)
            {
                g.Clear(BackColor);
                return bm;
            }
            g.Clear(Color.White);
            PointOfInterest topLeft = new PointOfInterest(_bounds.N, _bounds.W);
            //PointOfInterest topRight = new PointOfInterest(_bounds.N, _bounds.E);
            PointOfInterest bottomLeft = new PointOfInterest(_bounds.S, _bounds.W);
            PointOfInterest bottomRight = new PointOfInterest(_bounds.S, _bounds.E);
            Rectangle rBounds = new Rectangle(10, 10, pictureBox1.Width - 20, pictureBox1.Height - 20);
            double horizontalRes = bottomLeft.DistanceToPoint(bottomRight) / rBounds.Width;
            double verticalRes = topLeft.DistanceToPoint(bottomLeft) / rBounds.Height;
            if (horizontalRes < verticalRes)
            {
                double prop = horizontalRes / verticalRes;
                int newWidth = (int)(rBounds.Width * prop);
                rBounds.X = rBounds.X + (rBounds.Width - newWidth) / 2;
                rBounds.Width = newWidth;
            }
            else
            {
                double prop = verticalRes / horizontalRes;
                int newHeight = (int)(rBounds.Height * prop);
                rBounds.Y = rBounds.Y + (rBounds.Height - newHeight) / 2;
                rBounds.Height = newHeight;
            }
            double horizontalProp = rBounds.Width / Math.Abs(_bounds.W - _bounds.E);
            double verticalProp = rBounds.Height / Math.Abs(_bounds.N - _bounds.S);
            for (int i = 0; i < _tracks.Count; i++)
            {
                PointOfInterestList track = _tracks[i];
                // Started moving this into PointOfInterestList, but it has to recalculate some of the same values
                //track.CalcBBox(true);
                //float topLatitude = rBounds.Y + (float)(Math.Abs(track.BBox.N - bounds.N) * verticalProp);
                //float bottomLatitude = rBounds.Y + (float)(Math.Abs(track.BBox.S - bounds.N) * verticalProp);
                //float leftLongitude = rBounds.X + (float)(Math.Abs(track.BBox.W - bounds.W) * horizontalProp);
                //float rightLongitude = rBounds.X + (float)(Math.Abs(track.BBox.E - bounds.W) * horizontalProp);
                //RectangleF trackRect = new RectangleF(leftLongitude, topLatitude, rightLongitude - leftLongitude, bottomLatitude - topLatitude);
                Point lastPoint = Point.Empty;
                //track.DrawPath(e.Graphics);
                for (int j = 0; j < track.Count; j++)
                {
                    if (!track.PointIsTrimmed(j))
                    {
                        PointOfInterest point = track[j];
                        Point currentPoint = new Point(rBounds.X + (int)(Math.Abs(point.Longitude - _bounds.W) * horizontalProp), rBounds.Y + (int)(Math.Abs(point.Latitude - _bounds.N) * verticalProp));
                        if (!lastPoint.IsEmpty && (lastPoint.X != currentPoint.X || lastPoint.Y != currentPoint.Y))
                            g.DrawLine(new Pen(ColorGenerator.GetColorForTrack(i), (float)Settings.GMapsLineWidth), lastPoint, currentPoint);
                        lastPoint = currentPoint;
                    }
                }
            }
            return bm;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragX = e.X;
            dragY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //pictureBox1.Left = panel1.Width / 2 - e.X / 2;
                //pictureBox1.Top = panel1.Height / 2 - e.Y / 2;
                pictureBox1.Height /= 2;
                pictureBox1.Width /= 2;
                panel1.HorizontalScroll.Value = (int)(panel1.HorizontalScroll.Maximum * ((float)e.X / 2 / pictureBox1.Height));
                panel1.VerticalScroll.Value = (int)(panel1.VerticalScroll.Maximum * ((float)e.Y / 2 / pictureBox1.Width));
                pictureBox1.Image = Render();
                Zoom /= 2;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Point position = panel1.PointToClient(Cursor.Position);
                //pictureBox1.Location = new Point(pictureBox1.Left + e.X - dragX, pictureBox1.Top + e.Y - dragY);
                //pictureBox1.Left += (e.X - dragX);
                //pictureBox1.Top += (e.Y - dragY);
                panel1.HorizontalScroll.Value += (int)(panel1.HorizontalScroll.Maximum * ((float)e.X / pictureBox1.Height));
                panel1.VerticalScroll.Value += (int)(panel1.VerticalScroll.Maximum * ((float)e.Y / pictureBox1.Width));
                //dragX = e.X;
                //dragY = e.Y;
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.Height *= 2;
            pictureBox1.Width *= 2;
            panel1.HorizontalScroll.Value = (int)(panel1.HorizontalScroll.Maximum * ((float)dragX * 2 / pictureBox1.Height));
            panel1.VerticalScroll.Value = (int)(panel1.VerticalScroll.Maximum * ((float)dragY * 2 / pictureBox1.Width));
            //pictureBox1.Left = panel1.Width / 2 - dragX * 2;
            //pictureBox1.Top = panel1.Height / 2 - dragY * 2;
            pictureBox1.Image = Render();
            Zoom *= 2;
        }
    }
}
