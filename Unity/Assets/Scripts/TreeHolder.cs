using GenericTree.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityTree.Octree;

public class TreeHolder : MonoBehaviour
{
    [Header("Settings...")]
    public Vector3 size;
    public int maxDepth;
    public int maxLeafsPerNode;

    [Header("Leafs...")]
    public List<GameObject> prefabs;
    public float radius;
    public int count;

    [Header("Debug...")]
    public Color treeColor;
    public Color nodeColor;
    public Color spawnAreaColor;

    public Octree tree;


    void Start()
    {
        tree = new Octree(transform.position, size, maxDepth, maxLeafsPerNode);

        for (int i = 0; i < count; i++)
            SpawnAndAdd();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SpawnAndAdd();
    }

    private void SpawnAndAdd()
    {
        var prefab = prefabs[Random.Range(0, prefabs.Count)];
        tree.Add(
                Instantiate(prefab, Random.insideUnitSphere * radius, Quaternion.identity, transform)
                    .GetComponent<ILeaf<Vector3>>()
            );
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = spawnAreaColor;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = treeColor;
        Gizmos.DrawCube(transform.position, size);

        Gizmos.color = nodeColor;
        if (tree != null)
            foreach(var volume in tree.ListVolumes())
                Gizmos.DrawWireCube(volume.origin, volume.size);
    }
}
