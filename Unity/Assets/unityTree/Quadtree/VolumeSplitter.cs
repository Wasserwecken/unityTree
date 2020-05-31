using GenericTree.Common;
using UnityEngine;

namespace UnityTree.Quadtree
{
    public static class VolumeSplitter
    {
        public static Volume<Vector2>[] SplitUniform(Volume<Vector2> volume)
        {
            var splitSize = volume.size / 2f;
            var offset = splitSize / 2f;

            return new Volume<Vector2>[4]
            {
                new Volume<Vector2>(volume.origin + offset * new Vector2(1, 1), splitSize),
                new Volume<Vector2>(volume.origin + offset * new Vector2(-1, 1), splitSize),
                new Volume<Vector2>(volume.origin + offset * new Vector2(1, -1), splitSize),
                new Volume<Vector2>(volume.origin + offset * new Vector2(-1, -1), splitSize),
            };
        }
    }
}
