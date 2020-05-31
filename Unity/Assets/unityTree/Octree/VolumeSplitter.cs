using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Octree
{
    public static class VolumeSplitter
    {
        public static Volume<Vector3>[] SplitUniform(Volume<Vector3> volume)
        {
            var splitSize = volume.size / 2f;
            var offset = splitSize / 2f;

            return new Volume<Vector3>[8]
            {
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(1, 1, 1)), splitSize),
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(-1, 1, 1)), splitSize),
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(1, -1, 1)), splitSize),
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(-1, -1, 1)), splitSize),
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(1, 1, -1)), splitSize),
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(-1, 1, -1)), splitSize),
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(1, -1, -1)), splitSize),
                new Volume<Vector3>(volume.origin + Vector3.Scale(offset, new Vector3(-1, -1, -1)), splitSize)
            };
        }
    }
}
