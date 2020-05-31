using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Quadtree
{
    public struct Circle
    {
        public readonly Vector2 origin;
        public readonly float radius;

        public Circle(Vector2 origin, float radius)
        {
            this.origin = origin;
            this.radius = radius;
        }


        public bool TestIntersection(Volume<Vector2> volume)
            => TestIntersection(origin, radius, volume);

        public static bool TestIntersection(Circle sphere, Volume<Vector2> volume)
            => TestIntersection(sphere.origin, sphere.radius, volume);

        public static bool TestIntersection(Vector2 origin, float radius, Volume<Vector2> volume)
        {
            var volumeDelta = volume.size / 2f;
            var nearest = Vector2.Max(volume.origin - volumeDelta, Vector2.Min(volume.origin + volumeDelta, origin));
            var distance = Vector2.Distance(nearest, origin);

            return distance < radius;
        }
    }
}
