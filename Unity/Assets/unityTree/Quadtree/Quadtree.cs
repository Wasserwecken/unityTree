using GenericTree.Common;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTree.Quadtree
{
    public class Quadtree : RootBase<Vector2, Node<Vector2>>
    {
        public Quadtree(Vector2 origin, Vector2 size, int maxDepth, int maxLeafsPerNode)
            : base(origin, size, maxDepth, maxLeafsPerNode) { }


        public HashSet<ILeaf<Vector2>> FindByPoint(Vector2 point)
            => FindBy(point, Point.TestIntersection);


        public HashSet<ILeaf<Vector2>> FindByBox(Vector2 origin, Vector2 size)
            => FindByBox(new Box(origin, size));

        public HashSet<ILeaf<Vector2>> FindByBox(Box box)
            => FindBy(box, Box.TestIntersection);


        public HashSet<ILeaf<Vector2>> FindByCircle(Vector2 origin, float radius)
            => FindByCircle(new Circle(origin, radius));

        public HashSet<ILeaf<Vector2>> FindByCircle(Circle circle)
            => FindBy(circle, Circle.TestIntersection);


        protected override Node<Vector2> CreateRootNode()
            => new Node<Vector2>(Volume, 0, Depth, MaxLeafsPerNode, VolumeSplitter.SplitUniform);
    }
}
