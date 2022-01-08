using System;
using System.Drawing;
using System.Text;

namespace Pixelest.Builder
{
    public abstract class BoolMap
    {
        public bool[][] Values;
        public Size Size;
        public bool IsEmpty = true;

        protected BoolMap(Size size)
        {
            Size = size;
            Values = new bool[size.Width][];

            for (int i = 0; i < size.Width; i++)
                Values[i] = new bool[size.Height];
        }

        public static bool[][] And(BoolMap x, BoolMap y, out bool isEmpty)
        {
            isEmpty = true;

            int width = Math.Min(x.Size.Width, y.Size.Width);
            int height = Math.Min(x.Size.Height, y.Size.Height);
            Size size = new(width, height);

            bool[][] values = new bool[width][];

            for (int i = 0; i < x.Size.Width; i++)
            {
                values[i] = new bool[height];

                for (int j = 0; j < x.Size.Height; j++)
                {
                    bool value = x.Values[i][j] && y.Values[i][j];
                    
                    if(value)
                        isEmpty = false;

                    values[i][j] = value;
                }
            }
            
            return values;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder("\n");
            
            for (int i = 0; i < Size.Width; i++)
            {
                for (int j = 0; j < Size.Height; j++)
                    if(Values[i][j])
                        s.Append("0 ");
                    else
                        s.Append("_ ");

                s.Append("\n");
            }

            return s.ToString();
        }
    }
}