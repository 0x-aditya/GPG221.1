using UnityEngine;

namespace PathFinding
{
    public class AStar : MonoBehaviour
    {
        //open list
        //closed list
        //start node
        //end node
        //neighbour list
        //current node

        //start
        // append start node to open list

        //update
        // while true loop
        //   sort open list
        //   current node is the first value in the open list
        //   move current node from open to closed

        // if the current node is target node, break look

        // find neighbours of the current node and add it to a list

        // loop through the neighbors
        // if the neighbour node is not walkable or is in the closed list. continue the loop

        // if the neighbour node is not in open list or its g cost (or f cost since h cost does not change) 
        //   update the gcost and hcost
        //   set parent of the neighbour node to be the current
        //   if the neighbour is not in the open list, add it to the open list


    }
}

