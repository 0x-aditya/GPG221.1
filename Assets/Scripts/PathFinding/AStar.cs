using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class AStar: MonoBehaviour {
        public Transform seeker, target;
        Grid grid;

        void Awake() {
            grid = GetComponent<Grid>();
        }

        void Update() {
            FindPath(seeker.position, target.position);
        }

        void FindPath(Vector3 startPos, Vector3 targetPos) {
            Node startNode  = grid.NodeFromWorldPoint(startPos);
            Node targetNode = grid.NodeFromWorldPoint(targetPos);

            List<Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();

            openSet.Add(startNode);

            while (openSet.Count > 0) {
                Node currentNode = openSet[0];
                for (int i = 1; i < openSet.Count; i++) {
                    if (openSet[i].fCost < currentNode.fCost ||
                        (openSet[i].fCost == currentNode.fCost 
                         && openSet[i].hCost < currentNode.hCost)) {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == targetNode) {
                    RetracePath(startNode, targetNode);
                    return;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode)) {
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                        continue;

                    int newGCost = currentNode.gCost + GetDistance(currentNode, neighbour);

                    if (newGCost < neighbour.gCost || !openSet.Contains(neighbour)) {
                        neighbour.gCost = newGCost;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour);
                    }
                }
            }
        }

        void RetracePath(Node startNode, Node endNode) {
            List<Node> path = new List<Node>();
            Node current = endNode;

            while (current != startNode) {
                path.Add(current);
                current = current.parent;
            }
            path.Reverse();

            // move the enemy
        }

        int GetDistance(Node a, Node b) {
            int dstX = Mathf.Abs(a.gridX - b.gridX);
            int dstY = Mathf.Abs(a.gridY - b.gridY);

            if (dstX > dstY)
                return 14*dstY + 10*(dstX - dstY);
            return 14*dstX + 10*(dstY - dstX);
        }
    }
}

}
