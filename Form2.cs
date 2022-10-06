using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using Database;

namespace BattleshipTheGame
{
    public partial class Form2 : Form
    {
        private const int _amount = 6;
        private const int _width = 20;

        private Bitmap _bmp;
        private MovingFigures _aim;
        private SelfMovingFigures _prjct;
        private Ships[] _ships;
        private enum SLengths
        {
            Short = 20,
            Medium = 40,
            Long = 60
        }

        private bool _switcher; // makes sure you cannot take out >1 ship at once
        private int _defeated;

        public static int CWidth { get; set; }
        public static int CHeight { get; set; }

        private Timer _timer;
        private Timer _timer2;

        public Form2()
        {
            InitializeComponent();
            CWidth = this.ClientSize.Width;
            CHeight = this.ClientSize.Height;

            _bmp = new Bitmap(CWidth, CHeight);
            _aim = new MovingFigures();
            _prjct = new SelfMovingFigures();
            _ships = new Ships[_amount];
            InitShips();

            _switcher = false;
            _defeated = 0;
            InitTimers();

            RefreshBitmap();
            CurPrjct.Paint += CurPrjct_Paint;
            Canvas.MouseEnter += Canvas_MouseEnter;
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.MouseLeave += Canvas_MouseLeave;
            Canvas.Paint += Canvas_Paint;
            Canvas.Click += Shoot;
        }
        private void InitTimers()
        {
            _timer = new Timer();
            _timer.Tick += new EventHandler(TimerEventProcessor);
            _timer.Interval = 15; // ~60-70 fps
            _timer2 = new Timer();
            _timer2.Tick += new EventHandler(TimerEventProcessor2);
            _timer2.Interval = _timer.Interval;
            _timer.Start();
            _timer2.Start();
        }
        private void InitShips()
        {
            for (int i = 0; i < _amount; i++)
            {
                _ships[i] = new Ships();
                DbApp.GetShipParams(i, out string[] parameters);
                int startX, endX, pointX, pointY;
                startX = Convert.ToInt32(parameters[0]);
                endX = Convert.ToInt32(parameters[1]);
                pointX = Convert.ToInt32(parameters[2]);
                pointY = Convert.ToInt32(parameters[3]);
                int length = (int)Enum.Parse(typeof(SLengths), parameters[4]);
                _ships[i].Start = new PointF(startX, pointY);
                _ships[i].End = new PointF(endX, pointY);
                _ships[i].Point = new PointF(pointX, pointY);
                _ships[i].Path.AddRectangle(new Rectangle(pointX - length / 2, pointY - _width / 2, length, _width));
            }
        }
        private void RefreshBitmap()
        {
            if (_bmp != null) _bmp.Dispose();
            _bmp = new Bitmap(CWidth, CHeight);
            using (Graphics g = Graphics.FromImage(_bmp))
            {
                g.DrawPath(_aim.MyPen, _aim.Path);
                g.DrawPath(_prjct.MyPen, _prjct.Path);
                g.FillPath(_aim.MyBrush, _aim.Path);
                g.FillPath(_prjct.MyBrush, _prjct.Path);
                for (int i = 0; i < _amount; i++)
                {
                    g.DrawPath(_ships[i].MyPen, _ships[i].Path);
                    g.FillPath(_ships[i].MyBrush, _ships[i].Path);
                }
            }
        }
        private void Canvas_MouseEnter(object sender, EventArgs e)
        {
            _aim.MyPen = Pens.Red;
            _aim.MyBrush = Brushes.Red;
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            float deltaX, deltaY;
            deltaX = e.Location.X - _aim.Point.X;
            deltaY = e.Location.Y - _aim.Point.Y;
            _aim.Path.Transform(new Matrix(1, 0, 0, 1, deltaX, deltaY));
            _aim.Point = new PointF(e.Location.X, e.Location.Y);
        }
        private void Canvas_MouseLeave(object sender, EventArgs e)
        {
            _aim.Dispose();
            this.Refresh();
            _aim = new MovingFigures();
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_bmp == null) return;
            RefreshBitmap();
            e.Graphics.DrawImage(_bmp, 0, 0);
        }
        private void CurPrjct_Paint(object sender, PaintEventArgs e)
        {
            if (Form1.Player.CurPrjct > -1)
            {
                CurPrjct.Text = "Projectiles: " + Form1.Player.CurPrjct.ToString();
            }
            else
            {
                CurPrjct.Text = "";
            }
        }
        private void Shoot(object sender, EventArgs e)
        {
            _prjct.MyPen = Pens.Black;
            _prjct.MyBrush = Brushes.Black;
            Form1.Player.CurPrjct--;

            double x, y; // 12 and 37.5 are necessary fittings to the result, don't mind them
            x = MousePosition.X - this.Location.X - _prjct.Point.X - 12;
            y = MousePosition.Y - this.Location.Y - _prjct.Point.Y - 37.5;
            _prjct.Velocity = new Vector2((float)x, (float)y);
            _prjct.Velocity = Vector2.Normalize(_prjct.Velocity) * _prjct.Speed;
        }
        private void TimerEventProcessor(Object sender, EventArgs e)
        {
            _prjct.Path.Transform(new Matrix(1, 0, 0, 1, _prjct.Velocity.X, _prjct.Velocity.Y));
            _prjct.Point = new PointF(_prjct.Point.X + _prjct.Velocity.X, _prjct.Point.Y + _prjct.Velocity.Y);
            if (!Canvas.Bounds.Contains((int)_prjct.Point.X, (int)_prjct.Point.Y) || _switcher)
            {
                if (Form1.Player.CurPrjct == 0)
                {
                    Form1.Player.CurPrjct--;
                }
                _prjct.Dispose();
                _switcher = false;
                this.Refresh();
                _prjct = new SelfMovingFigures();
            }
            this.Refresh();
        }
        private void TimerEventProcessor2(Object sender, EventArgs e)
        {
            if (Form1.Player.CurPrjct == -1 || _defeated == _amount)
            {
                _timer.Stop();
                _timer2.Stop();
                Leave();
                return;
            }
            for (int i = 0; i < _amount; i++)
            {
                if (_ships[i].Point.X == _ships[i].Start.X)
                {
                    _ships[i].Velocity = new Vector2(_ships[i].Speed, 0f);
                }
                else if (_ships[i].Point.X == _ships[i].End.X)
                {
                    _ships[i].Velocity = new Vector2(-_ships[i].Speed, 0f);
                }

                if (_ships[i].Path.IsVisible(_prjct.Point))
                {
                    _ships[i].Path.Reset();
                    _defeated++;
                    Form1.Player.Score++;
                    _switcher = true;
                }
                _ships[i].Path.Transform(new Matrix(1, 0, 0, 1, _ships[i].Velocity.X, _ships[i].Velocity.Y));
                _ships[i].Point = new PointF(_ships[i].Point.X + _ships[i].Velocity.X, _ships[i].Point.Y);
            }
            this.Refresh();
        }
        private new void Leave()
        {
            Canvas.Cursor = Cursors.WaitCursor;
            Form3 Results = new Form3();
            Results.Show(this);
            this.Hide();
        }
    }
}