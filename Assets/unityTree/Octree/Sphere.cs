using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Octree
{
    public struct Sphere
    {
        public readonly Vector3 origin;
        public readonly float radius;

        public Sphere(Vector3 origin, float radius)
        {
            this.origin = origin;
            this.radius = radius;
        }


        public bool TestIntersection(Volume<Vector3> volume)
            => TestIntersection(origin, radius, volume);

        public static bool TestIntersection(Sphere sphere, Volume<Vector3> volume)
            => TestIntersection(sphere.origin, sphere.radius, volume);

        public static bool TestIntersection(Vector3 origin, float radius, Volume<Vector3> volume)
        {
            var volumeDelta = volume.size / 2f;
            var nearest = Vector3.Max(volume.origin - volumeDelta, Vector3.Min(volume.origin + volumeDelta, origin));
            var distance = Vector3.Distance(nearest, origin);

            return distance < radius;
        }
    }
}
