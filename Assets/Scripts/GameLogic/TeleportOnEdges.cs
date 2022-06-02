using UnityEngine;

namespace Game.Logic
{
    public class TeleportOnEdges
    {
        private readonly ScreenEdges edges;

        public TeleportOnEdges(ScreenEdges edges)
        {
            this.edges = edges;
        }

        public void TeleportationToTop(Transform transform)
        {
            if (transform.position.y < edges.Bottom)
            {
                transform.position = new Vector2(transform.position.x, edges.Top);
            }
        }

        public void TeleportationToBottom(Transform transform)
        {
            if (transform.position.y > edges.Top)
            {
                transform.position = new Vector2(transform.position.x, edges.Bottom);
            }
        }

        public void TeleportationToLeft(Transform transform)
        {
            if (transform.position.x > edges.Right)
            {
                transform.position = new Vector2(edges.Left, transform.position.y);
            }
        }

        public void TeleportationToRight(Transform transform)
        {
            if (transform.position.x < edges.Left)
            {
                transform.position = new Vector2(edges.Right, transform.position.y);
            }
        }
    }    
}
