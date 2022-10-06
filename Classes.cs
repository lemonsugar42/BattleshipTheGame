using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;

namespace BattleshipTheGame
{
    public class MovingFigures : IDisposable
    {
        private const int _radius = 7;
        public GraphicsPath Path { get; set; }
        public Pen MyPen { get; set; }
        public Brush MyBrush { get; set; }
        public PointF Point { get; set; }
        public MovingFigures()
        {
            MyPen = Pens.Transparent;
            MyBrush = Brushes.Transparent;
            Path = new GraphicsPath();
            Path.AddEllipse(Rectangle.FromLTRB(0, 0, _radius, _radius));
            Point = new PointF(_radius / 2f, _radius / 2f);
        }
        public virtual void Dispose()
        {
        }
    }
    public class SelfMovingFigures : MovingFigures
    {
        private const int _radius = 8;
        private const int _offset = 4;
        public Vector2 Velocity { get; set; }
        public virtual float Speed { get; }
        public SelfMovingFigures() : base()
        {
            MyPen = Pens.Transparent;
            MyBrush = Brushes.Transparent;
            Path = new GraphicsPath();
            Path.AddEllipse(Rectangle.FromLTRB(Form2.CWidth / 2,
                                               Form2.CHeight - _radius - _offset,
                                               Form2.CWidth / 2 + _radius,
                                               Form2.CHeight - _offset));
            Point = new PointF(Form2.CWidth / 2 + _offset, Form2.CHeight - _radius);
            Velocity = new Vector2(0f);
            Speed = 15;
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
    public class Ships : SelfMovingFigures
    {
        public override float Speed { get; }
        public PointF Start { get; set; }
        public PointF End { get; set; }
        public Ships() : base()
        {
            MyPen = Pens.Blue;
            MyBrush = Brushes.Blue;
            Path = new GraphicsPath();
            Speed = 1;
            Velocity = new Vector2(Speed, 0f);
        }
    }
}