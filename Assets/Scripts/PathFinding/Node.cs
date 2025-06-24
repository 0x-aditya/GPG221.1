using UnityEngine;

namespace PathFinding
{
    public class Node {
        public bool walkable;
        public Vector3 worldPosition;
        public int gridX, gridY;

        public int gCost;
        public int hCost;
        public Node parent;

        public int FCost
        {
            get
            {
                return gCost + hCost;
            }
        }

        public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY) {
            walkable     = _walkable;
            worldPosition = _worldPos;
            gridX        = _gridX;
            gridY        = _gridY;
        }
    }
}

