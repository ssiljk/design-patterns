using System;
using Newtonsoft.Json;

namespace DeepCopy
{


    public class Point
    {
        public int X, Y;
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
    }

    public class Line
    {
        public Point Start, End;
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        public Line CopyFull()
        {
            string json = JsonConvert.SerializeObject(this);
            Line copy = JsonConvert.DeserializeObject<Line>(json);
            return copy;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Line l1 = new Line(p1,p2);
           
            Line l2 = l1.CopyFull();
            l2.End.X = 3;
            l2.End.Y = 3;

            Console.ReadKey();

        }
    }
}
