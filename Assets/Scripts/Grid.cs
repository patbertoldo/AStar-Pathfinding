using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{

    public class Grid : MonoBehaviour
    {
        [SerializeField]
        private int sizeX = 15;

        [SerializeField]
        private int sizeZ = 15;

        [SerializeField]
        private GameObject gridNode;

        [SerializeField]
        private Vector3 positionOffset;

        [SerializeField]
        private Vector3 rotation;

        [SerializeField]
        private int obstacleChance = 5;

        private List<GridNode> gridNodes;

        private void Awake()
        {
            gridNodes = new List<GridNode>();
        }

        [ContextMenu("Build")]
        public void BuildGrid()
        {
            ClearGrid();

            // Build
            for (int x = 0; x < sizeX; x++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    Vector3 position = new Vector3(x, 0, z) + positionOffset;
                    Quaternion quaternion = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

                    GameObject newGridNode = Instantiate(gridNode, position, quaternion, transform);
                    newGridNode.name = $"{x}_{z}";

                    gridNodes.Add(newGridNode.GetComponent<GridNode>());
                }
            }

            System.GC.Collect();
        }

        private void ClearGrid()
        {
            if (gridNodes != null)
            {
                for (int i = gridNodes.Count - 1; i >= 0; i--)
                {
                    Destroy(gridNodes[i].gameObject);
                    gridNodes.RemoveAt(i);
                }

                gridNodes.Clear();
            }
        }

        [ContextMenu("Build and Randomize")]
        public void BuildAndRandomizeGrid()
        {
            ClearGrid();
            BuildGrid();
            RandomizeGrid();
        }

        [ContextMenu("Randomize")]
        public void RandomizeGrid()
        {
            System.Random random = new System.Random();

            foreach(GridNode gridNode in gridNodes)
            {
                int gridType = random.Next(obstacleChance);
                gridNode.Initialise(gridType == 0 ? NodeTypes.Obstacle : NodeTypes.None);
            }
        }

        private void OnDestroy()
        {
            ClearGrid();
        }
    }
}