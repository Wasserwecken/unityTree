using GenericTree.Common;
using UnityEngine;
using UnityTree.Octree;

public class BoxLeaf : MonoBehaviour, ILeaf<Vector3>
{
    [Header("References...")]
    public Transform visuals;

    [Header("Settings...")]
    public float maxSize;
    public float minSize;

    private Box boundingBox;


    void Awake()
    {
        var size = Vector3.one * minSize + Random.insideUnitSphere * (maxSize - minSize);

        boundingBox = new Box(transform.position, size);
        visuals.localScale = size;
    }

    public bool IntersectionTest(Volume<Vector3> volume)
        => boundingBox.TestIntersection(volume);
}
