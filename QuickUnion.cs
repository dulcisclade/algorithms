using System;
namespace concole
{
    public class QuickUnion
    {
        private Point[] points;

        public QuickUnion(int count)
        {
            points = new Point[count];

            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(i);
            }
        }
    }

    public class Point
    {
        public int Value { get; private set; }
        public Point NextPoint { get; private set; }
        public int Size { get; private set; }

        public Point(int value)
        {
            this.Value = value;
            this.NextPoint = this;
            Size = 1;
        }

        private Point Root()
        {
            Point currentPoint = this;
            while (currentPoint != currentPoint.NextPoint)
            {
                currentPoint = NextPoint.NextPoint;
            }

            return currentPoint;
        }

        public bool IsConnectedWith(Point item)
        {
            var thisRoot = this.Root();
            var itemRoot = item.Root();

            return IsRootsEquals(thisRoot, itemRoot);
        }

        private bool IsRootsEquals(Point thisRoot, Point itemRoot)
        {
            return thisRoot.Value == itemRoot.Value && thisRoot.Size == itemRoot.Size;
        }


        public void Connect(Point item)
        {
            var thisRoot = this.Root();
            var itemRoot = item.Root();

            if (IsRootsEquals(thisRoot, itemRoot))
            {
                return;
            }

            if (itemRoot.Size >= thisRoot.Size)
            {
                itemRoot.Size += thisRoot.Size;
                thisRoot.Size = 1;
                thisRoot.NextPoint = itemRoot;
            }

            else
            {
                thisRoot.Size += itemRoot.Size;
                itemRoot.Size = 1;
                itemRoot.NextPoint = itemRoot;
            }
        }
    }
}
