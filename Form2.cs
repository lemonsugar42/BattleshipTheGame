using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BattleshipTheGame
{
    public partial class Form2 : Form
    {
        private static Bitmap _bmp;
        private readonly MovingFigures _dot;
        private Point _point;
        public static int CWidth { get; set; }
        public static int CHeight { get; set; }
        public Form2()
        {
            InitializeComponent();
            CWidth = this.ClientSize.Width;
            CHeight = this.ClientSize.Height;
            _bmp = new Bitmap(CWidth, CHeight);
            _dot = new MovingFigures();
            InitDot();
            Canvas.MouseEnter += Canvas_MouseEnter;
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.MouseLeave += Canvas_MouseLeave;
            Canvas.Paint += Canvas_Paint;
            Button.Click += Button_Click;
        }
        private void RefreshBitmap()
        {
            if (_bmp != null) _bmp.Dispose();
            _bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(_bmp))
            {
                g.DrawPath(_dot.MyPen, _dot.Path);
                g.FillPath(_dot.MyBrush, _dot.Path);
            }
        }
        private void InitDot()
        {
            _dot.MyPen = Pens.Transparent;
            _dot.MyBrush = Brushes.Transparent;
            _dot.Path = new GraphicsPath();
            _dot.Path.AddEllipse(Rectangle.FromLTRB(0, 0, 7, 7));
            _point.X = 0;
            _point.Y = 0;
            RefreshBitmap();
        }
        private void Canvas_MouseEnter(object sender, EventArgs e)
        {
            _dot.MyPen = Pens.Red;
            _dot.MyBrush = Brushes.Red;
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX, deltaY;
            deltaX = e.Location.X - _point.X;
            deltaY = e.Location.Y - _point.Y;
            _dot.Path.Transform(new Matrix(1, 0, 0, 1, deltaX, deltaY));
            _point = e.Location;
            this.Refresh();
        }
        private void Canvas_MouseLeave(object sender, EventArgs e)
        {
            _dot.Path.Reset();
            this.Refresh();
            InitDot();
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_bmp == null) return;
            RefreshBitmap();
            e.Graphics.DrawImage(_bmp, 0, 0);
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Form1.Player.Score = Convert.ToInt32(ListBox.Text);
            this.Button.Cursor = Cursors.WaitCursor;
            Form3 Results = new Form3();
            Results.Show(this);
            this.Hide();
        }
    }
    public class MovingFigures
    {
        public GraphicsPath Path { get; set; }
        public Pen MyPen { get; set; }
        public Brush MyBrush { get; set; }
    }
}
