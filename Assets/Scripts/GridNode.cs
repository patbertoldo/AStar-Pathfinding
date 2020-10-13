using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public enum NodeTypes
    {
        None,
        Start,
        Destination,
        Obstacle
    }

    public class GridNode : MonoBehaviour
    {
        private NodeTypes nodeType;

        [SerializeField]
        private MeshRenderer meshRenderer;

        public void Initialise(NodeTypes nodeType)
        {
            switch(nodeType)
            {
                case NodeTypes.None:
                    meshRenderer.material.color = Color.white;
                    break;
                case NodeTypes.Start:
                    meshRenderer.material.color = Color.green;
                    break;
                case NodeTypes.Destination:
                    meshRenderer.material.color = Color.red;
                    break;
                case NodeTypes.Obstacle:
                    meshRenderer.material.color = Color.black;
                    break;
            }
        }
    }
}
