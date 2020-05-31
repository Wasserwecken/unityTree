using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Quadtree
{
    public struct Point
    {
        public readonly Vector2 position;

        public Point(Vector2 position)
        {
            this.position = position;
        }


        public bool TestIntersection(Volume<Vector2> volume)
            => TestIntersection(position, volume);

        public static bool TestIntersection(Point point, Volume<Vector2> volume)
            => TestIntersection(point.position, volume);

        public static bool TestIntersection(Vector2 position, Volume<Vector2> volume)
        {
            var delta = volume.size / 2f;
            return !(position.x < volume.origin.x - delta.x) && !(position.x > volume.origin.x + delta.x) &&
                   !(position.y < volume.origin.y - delta.y) && !(position.y > volume.origin.y + delta.y)
                ;
        }
    }
}
