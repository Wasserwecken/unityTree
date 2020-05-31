using GenericTree.Common;
using UnityEngine;
using UnityTree.Octree;

public class LeafSphere : MonoBehaviour, ILeaf<Vector3>
{
    [Header("References...")]
    public Transform visuals;

    [Header("Settings...")]
    public float maxRadius;
    public float minRadius;

    private Sphere boundingSphere;


    void Awake()
    {
        var radius = Random.Range(minRadius, maxRadius);

        boundingSphere = new Sphere(transform.position, radius);
        visuals.localScale = Vector3.one * radius;
    }

    public bool IntersectionTest(Volume<Vector3> volume)
        => boundingSphere.TestIntersection(volume);
}
