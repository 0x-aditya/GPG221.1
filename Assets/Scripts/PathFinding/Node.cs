using UnityEngine;

namespace PathFinding
{
    public class Node
    {
        // Each block in a grid to form a path
        
        public readonly bool Walkable; // Check is the node is obstructed
        public Vector3 WorldPosition; // Node position
        public readonly int GridX; // Position in grid X
        public readonly int GridY; // Position in grid Y

        private int _gCost; //  Cost from start node to the current node following parents path
        private int _hCost; // Heuristic cost from current node to goal node
        public Node Parent; // 

        public int FCost => _gCost + _hCost; // adds both costs to find next path to search

        public Node(bool walkable, Vector3 worldPos, int gridX, int gridY)
        {
            // Initializing variables in constructor
            Walkable = walkable;
            WorldPosition = worldPos;
            GridX = gridX;
            GridY = gridY;
            _gCost = 0;
            _hCost = 0;
        }
    }
}

