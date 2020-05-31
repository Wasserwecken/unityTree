using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Quadtree
{
    public struct Box
    {
        public readonly Vector2 origin;
        public readonly Vector2 size;
        public readonly Vector2 minBounds;
        public readonly Vector2 maxBounds;

        public Box(Vector2 origin, Vector2 size)
        {
            this.origin = origin;
            this.size = size;

            var delta = size / 2f;
            minBounds = origin - delta;
            maxBounds = origin + delta;
        }

        public bool TestIntersection(Volume<Vector2> volume)
            => TestIntersection(minBounds, maxBounds, volume);

        public static bool TestIntersection(Box box, Volume<Vector2> volume)
            => TestIntersection(box.minBounds, box.maxBounds, volume);

        public static bool TestIntersection(Vector2 minBounds, Vector2 maxBounds, Volume<Vector2> volume)
        {
            var volumeDelta = volume.size / 2f;
            return !(maxBounds.x < volume.origin.x - volumeDelta.x) && !(minBounds.x > volume.origin.x + volumeDelta.x) &&
                   !(maxBounds.y < volume.origin.y - volumeDelta.y) && !(minBounds.y > volume.origin.y + volumeDelta.y)
                ;
        }
    }
}
