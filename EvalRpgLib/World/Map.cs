using System;
using EvalRpgLib.Beings;
using EvalRpgLib.Exemples;
using EvalRpgLib.Helpers;

namespace EvalRpgLib.World
{
    public class Map
    {
        // Init map width
        public const int WIDTH = 10;

        // Init map height
        public const int HEIGHT = 10;

        // Init matrix elements
        public MapElement[,] Matrix { get; set; }

        // Init constructor
        public Map() : this(WIDTH, HEIGHT) { }

        // Init map size
        public Map(int width, int height)
        {
            if (width == 10 && height == 10)
            {
                Matrix = new MapElement[HEIGHT, WIDTH];
                for (int i = 0; i < HEIGHT; i++){
                    for (int j = 0; j < WIDTH; j++) {
                        Matrix[i, j] = new MapElement(this, i, j);
                    }
                }

            }
            else
            {
                Matrix = new MapElement[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Matrix[i, j] = new MapElement(this, i, j);
                    }
                }
            }


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Matrix[i, j].SearchNeighbors();
                }
            }
            
        }

        // Map elements simplification
        public MapElement this[int i, int j]
        {
            get
            {
                return IndexesInMatrix(i, j) ? Matrix[i, j] : null;
            }
            set
            {
                if(IndexesInMatrix(i, j))
                {
                    Matrix[i, j] = value;
                }
            }
        }

        // If params in map size true else false
        public bool IndexesInMatrix(int i, int j)
        {
            if (i < Matrix.GetLength(0) && j < Matrix.GetLength(1) && i >= 0 && j >= 0){
                return true;
            } else {
                return false;
            }

        }




    }
}
