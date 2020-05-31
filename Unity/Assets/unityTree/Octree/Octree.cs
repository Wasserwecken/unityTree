using GenericTree.Common;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTree.Octree
{
    public class Octree : RootBase<Vector3, Node<Vector3>>
    {
        public Octree(Vector3 origin, Vector3 size, int maxDepth, int maxLeafsPerNode)
            : base(origin, size, maxDepth, maxLeafsPerNode) { }


        public HashSet<ILeaf<Vector3>> FindByPoint(Vector3 point)
            => FindBy(point, Point.TestIntersection);

        public void FindByPoint(HashSet<ILeaf<Vector3>> result, Vector3 point)
            => FindBy(result, point, Point.TestIntersection);


        public HashSet<ILeaf<Vector3>> FindByBox(Vector3 origin, Vector3 size)
            => FindByBox(new Box(origin, size));

        public HashSet<ILeaf<Vector3>> FindByBox(Box box)
            => FindBy(box, Box.TestIntersection);
        
        public void FindByBox(HashSet<ILeaf<Vector3>> result, Vector3 origin, Vector3 size)
            => FindByBox(result, new Box(origin, size));

        public void FindByBox(HashSet<ILeaf<Vector3>> result,  Box box)
            => FindBy(result, box, Box.TestIntersection);


        public HashSet<ILeaf<Vector3>> FindBySphere(Vector3 origin, float radius)
            => FindBySphere(new Sphere(origin, radius));

        public HashSet<ILeaf<Vector3>> FindBySphere(Sphere sphere)
            => FindBy(sphere, Sphere.TestIntersection);

        public void FindBySphere(HashSet<ILeaf<Vector3>> result, Vector3 origin, float radius)
            => FindBySphere(result, new Sphere(origin, radius));

        public void FindBySphere(HashSet<ILeaf<Vector3>> result, Sphere sphere)
            => FindBy(result, sphere, Sphere.TestIntersection);


        protected override Node<Vector3> CreateRootNode()
            => new Node<Vector3>(Volume, 0, MaxDepth, MaxLeafsPerNode, VolumeSplitter.SplitUniform);
    }
}
