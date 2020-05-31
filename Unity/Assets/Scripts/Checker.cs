using GenericTree.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Checker : MonoBehaviour
{
    [Header("Settings...")]
    public TreeHolder holder;
    public float searchRadius;
    public float moveRadius;

    [Header("Debug...")]
    public Color lineColor;
    public Color searchColor;

    private List<GameObject> neighbours;
    private float timeOffset;
    private Vector3 timeScale;


    void Start()
    {
        neighbours = new List<GameObject>();
        timeOffset += Random.value;
        timeScale = new Vector3(
            Random.Range(0.1f, 1f),
            Random.Range(0.1f, 1f),
            Random.Range(0.1f, 1f)
        );
    }

    void Update()
    {
        var time = timeOffset + Time.realtimeSinceStartup;
        var newPosition = new Vector3(
            Mathf.Sin(time * timeScale.x),
            Mathf.Cos(time * timeScale.y),
            -Mathf.Sin(time * timeScale.z)
        );
        transform.position = newPosition * moveRadius;

        Profiler.BeginSample("Sphere search");
        var leafs = holder.tree.FindBySphere(transform.position, searchRadius);
        Profiler.EndSample();

        neighbours.Clear();
        foreach (var leaf in leafs)
            neighbours.Add(((MonoBehaviour)leaf).gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = searchColor;
        Gizmos.DrawSphere(transform.position, searchRadius);

        Gizmos.color = lineColor;
        if(neighbours != null)
            foreach (var neighbour in neighbours)
                Gizmos.DrawLine(transform.position, neighbour.transform.position);
    }
}
