using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Octree
{
    public struct Point
    {
        public readonly Vector3 position;

        public Point(Vector3 position)
        {
            this.position = position;
        }


        public bool TestIntersection(Volume<Vector3> volume)
            => TestIntersection(position, volume);

        public static bool TestIntersection(Point point, Volume<Vector3> volume)
            => TestIntersection(point.position, volume);

        public static bool TestIntersection(Vector3 position, Volume<Vector3> volume)
        {
            var delta = volume.size / 2f;
            return !(position.x < volume.origin.x - delta.x) && !(position.x > volume.origin.x + delta.x) &&
                   !(position.y < volume.origin.y - delta.y) && !(position.y > volume.origin.y + delta.y) &&
                   !(position.z < volume.origin.z - delta.z) && !(position.z > volume.origin.z + delta.z)
                ;
        }
    }
}
