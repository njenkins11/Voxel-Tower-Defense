using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grassPrefab;
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject grassCubePrefab;
    [SerializeField] private GameObject towerSpawnPrefab;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private GameObject bridgePrefab;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;

    [SerializeField] private float grassChance;
    [SerializeField] private float treeChance;
    [SerializeField] private float rockChance;
    [SerializeField] private float flowerChance;


    public void GenerateWorld()
    {
       GenerateGround();
       GenerateBridge();
    }

    private void GenerateBridge()
    {
        GameObject lastPath = PathGenerator.path[PathGenerator.path.Count-1];
        Instantiate(bridgePrefab, new Vector3(lastPath.transform.position.x,-0.7f,lastPath.transform.position.z+0.85f), Quaternion.identity, transform); 
    }   

    private void GenerateGround()
    {
        float y;
        for(int col = 0; col < PathGenerator.grid.GetLength(0); col++)
            for(int row = 0; row < PathGenerator.grid.GetLength(1); row++)
            {
                y = Random.Range(minHeight, maxHeight);
                if(PathGenerator.grid[col,row] == 0 )
                {
                    GameObject grassBlock = Instantiate(grassCubePrefab, new Vector3(col, y-1.5f, row), Quaternion.identity, transform);
                    GenerateNature(grassBlock, col,y,row);
                }
                else if(PathGenerator.grid[col,row] == 2 )
                {
                    GameObject grassBlock = Instantiate(grassCubePrefab, new Vector3(col,-1.5f, row), Quaternion.identity, transform);
                }
            }

    }

    private void GenerateNature(GameObject parent, float x, float y, float z)
    {
        double spawn = Random.value;
        if(spawn < grassChance)
            Instantiate(grassPrefab, new Vector3(parent.transform.position.x+0.5f,y-0.7f,parent.transform.position.z-0.5f), Quaternion.identity, transform);
        else if (spawn < grassChance + treeChance)
               Instantiate(treePrefab, new Vector3(parent.transform.position.x+0.6f,y-1f,parent.transform.position.z-0.1f), Quaternion.identity, transform);
        else if (spawn < grassChance+treeChance+rockChance)
                Instantiate(rockPrefab, new Vector3(parent.transform.position.x+0.5f,y-0.6f,parent.transform.position.z-0.5f), Quaternion.identity, transform);
        else if (spawn < grassChance + treeChance + rockChance+flowerChance)
                Instantiate(flowerPrefab, new Vector3(parent.transform.position.x+0.5f,y-0.7f,parent.transform.position.z-0.5f), Quaternion.identity, transform);
    } 
}
