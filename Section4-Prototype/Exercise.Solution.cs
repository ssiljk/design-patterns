using System;

  namespace Coding.Exercise
  {
    public class Point
    {
        public int X, Y;
        
        public Point()
        {
            X = 0;
            Y = 0;
        }
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
    }

    public class Line
    {
        public Point Start, End;
        public Line()
        {
            Start = new Point();
            End = new Point();
        }
        
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        public Line DeepCopy()
        {
            Line copy = new Line();
            copy.Start.X = this.Start.X;
            copy.Start.Y = this.Start.Y;
            copy.End.X = this.End.X;
            copy.End.Y = this.End.Y;
            return copy;
        }

    }
  }
