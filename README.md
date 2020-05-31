# UnityTree
Quadtree and Octree implementation for unity based on the
[genericTree](https://github.com/Wasserwecken/genericTree) project.  

![Octree visualisation](/gitMedia/octree.png)

## Install
Import the unityPackage from the release tab. Dependencies are included.

## Usage
This is a `MonoBehaviour` independend implementation. There is no constraint to use the API within a `MonoBehaviour`. Only `UnityEngine.Vector3` and `UnityEngine.Vector2` is required from Unity.

### Initialisation

```c#
public class Example : MonoBehaviour
{
    public Vector3 size;
    public int maxDepth;
    public int maxLeafsPerNode;

    public Octree tree;

    void Start()
    {
        tree = new Octree(transform.position, size, maxDepth, maxLeafsPerNode);
    }
}
```

### Search, add and remove leafs

```c#
public class Example : MonoBehaviour
{
    public Octree tree;

    void Update()
    {
        // ExampleItem have to implement the ILeaf<T> interface
        var leaf = new ExampleItem();

        // add a leaf to the structure
        tree.Add(leaf);

        // search for leafs nearby
        var leafs = tree.FindBySphere(transform.position, searchRadius);

        // removes a leaf from the structure
        tree.Remove(leaf);
    }
}
```

### Leaf implementation example

```c#
public class BoxLeaf : MonoBehaviour, ILeaf<Vector3>
{
    public Vector3 size;
    private Box boundingBox;

    void Awake()
    {
        boundingBox = new Box(transform.position, size);
    }

    public bool IntersectionTest(Volume<Vector3> volume)
        => boundingBox.TestIntersection(volume);
}

```