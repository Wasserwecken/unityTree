using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Octree
{
    public struct Box
    {
        public readonly Vector3 origin;
        public readonly Vector3 size;
        public readonly Vector3 minBounds;
        public readonly Vector3 maxBounds;

        public Box(Vector3 origin, Vector3 size)
        {
            this.origin = origin;
            this.size = size;

            var delta = size / 2f;
            minBounds = origin - delta;
            maxBounds = origin + delta;
        }

        public bool TestIntersection(Volume<Vector3> volume)
            => TestIntersection(minBounds, maxBounds, volume);

        public static bool TestIntersection(Box box, Volume<Vector3> volume)
            => TestIntersection(box.minBounds, box.maxBounds, volume);

        public static bool TestIntersection(Vector3 minBounds, Vector3 maxBounds, Volume<Vector3> volume)
        {
            var volumeDelta = volume.size / 2f;
            return !(maxBounds.x < volume.origin.x - volumeDelta.x) && !(minBounds.x > volume.origin.x + volumeDelta.x) &&
                   !(maxBounds.y < volume.origin.y - volumeDelta.y) && !(minBounds.y > volume.origin.y + volumeDelta.y) &&
                   !(maxBounds.z < volume.origin.z - volumeDelta.z) && !(minBounds.z > volume.origin.z + volumeDelta.z)
                ;
        }
    }
}
