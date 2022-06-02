using UnityEngine;

namespace Game.Logic
{

    public class ScreenDiagonal
    {
        public float Height { get; private set; }
        public float Width { get; private set; }

        public float GetHeight(Camera main)
        {
            return Height = main.orthographicSize * 2;
        }

        public float GetWidth(Camera main)
        {
            return Width = main.orthographicSize * 2 * main.aspect;
        }
    }

    public class ScreenEdges
    {
        public float Top { get; private set; }
        public float Bottom { get; private set; }
        public float Right { get; private set; }
        public float Left { get; private set; }

        private readonly ScreenDiagonal diagonal;

        public ScreenEdges(ScreenDiagonal diagonal)
        {
            this.diagonal = diagonal;
        }

        public float GetTop()
        {
            return Top = diagonal.Height / 2;
        }

        public float GetBottom()
        {
            return Bottom = Top * -1;
        }

        public float GetRight()
        {
            return Right = diagonal.Width / 2;
        }

        public float GetLeft()
        {
            return Left = Right * -1;
        }
    }
}