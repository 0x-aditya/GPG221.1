using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class Grid : MonoBehaviour {
        public int gridSizeX;
        public int gridSizeY;
        public string obstacleTag = "Obstacle";

        Node[,] grid;
        public float nodeSize = 1f;
        void Awake() {
            CreateGrid();
        }

        void CreateGrid() {
            grid = new Node[gridSizeX, gridSizeY];
            Vector3 bottomLeft = transform.position
                                 - Vector3.right * gridWorldSize.x/2
                                 - Vector3.up    * gridWorldSize.y/2;

            for (int x = 0; x < gridSizeX; x++) {
                for (int y = 0; y < gridSizeY; y++) {
                    Vector3 worldPoint = bottomLeft 
                                         + Vector3.right * (x * nodeSize + nodeRadius)
                                         + Vector3.up    * (y * nodeSize + nodeRadius);

                    Collider2D hit = Physics2D.OverlapCircle(worldPoint, nodeRadius);
                
                    bool walkable = hit == null || !hit.CompareTag(obstacleTag);

                    grid[x,y] = new Node(walkable, worldPoint, x, y);
                }
            }
        }

        public List<Node> GetNeighbours(Node node) {
            var neighbours = new List<Node>();

            for (int dx = -1; dx <= 1; dx++) {
                for (int dy = -1; dy <= 1; dy++) {
                    if (dx == 0 && dy == 0) continue;
                    int checkX = node.gridX + dx;
                    int checkY = node.gridY + dy;
                    if (checkX >= 0 && checkX < gridSizeX &&
                        checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbours.Add(grid[checkX, checkY]);
                    }
                }
            }
            return neighbours;
        }

        public Node NodeFromWorldPoint(Vector3 worldPos) {
            float percentX = (worldPos.x + gridWorldSize.x/2) / gridWorldSize.x;
            float percentY = (worldPos.y + gridWorldSize.y/2) / gridWorldSize.y;
            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);

            int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
            int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
            return grid[x,y];
        }
    }
}

}
