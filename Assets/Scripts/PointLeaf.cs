using GenericTree.Common;
using UnityEngine;
using UnityTree.Octree;

public class PointLeaf : MonoBehaviour, ILeaf<Vector3>
{
    public bool IntersectionTest(Volume<Vector3> volume)
        => Point.TestIntersection(transform.position, volume);
}
