using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    [SerializeField] private int size = 20;
    [SerializeField] private GameObject pathWayPointPrefab;
    [SerializeField] private GameObject dirtPathPrefab;
    [SerializeField] private GameObject towerWayPointPrefab;
    [SerializeField] private GameObject towerAreaPrefab;
    [SerializeField] private GameObject towerButtonPrefab;
    [SerializeField] private Transform mapCanvasTransform;
    [SerializeField] private int boundingBox;
    public static List<GameObject> path;
    public static int[,] grid;
    private int turnCoolDown;

    // Start is called before the first frame update
    void Awake()
    {
        grid = new int[size, size];
        path = new List<GameObject>();
        createGrid();
        CreateTowerLocations();
        GetComponent<WorldGenerator>().GenerateWorld();
    }

    private void createGrid()
    {
        int x = 0, z = Random.Range(0, size);
        int nextMove, prevMove = -1;
        while(z > size - boundingBox || z < boundingBox)
            z = Random.Range(0, size);
        fillGridWithPath(x, z);
        while (x < size - 1)
        {
            nextMove = Random.Range(0, 3);
            while ((nextMove == 0 && prevMove == 1) || (nextMove == 1 && prevMove == 0))
            {
                nextMove = Random.Range(0, 3);
            }
            prevMove = nextMove;
            switch (nextMove)
            {
                case 0:
                    if (z < size - boundingBox)
                        z++;
                    else
                    {
                        x++;
                        prevMove = 2;
                    }
                    break;
                case 1:
                    if (z > boundingBox)
                        z--;
                    else
                    {
                        x++;
                        prevMove = 2;
                    }
                    break;
                case 2:
                    x++;
                    break;
            }
            fillGridWithPath(x, z);
        }
    }

    private void fillGridWithPath(int x, int z)
    {
        grid[x, z] = 1;
        GameObject dirtBlock = Instantiate(dirtPathPrefab, new Vector3(x, -1.5f, z), Quaternion.identity, transform);
        path.Add(Instantiate(pathWayPointPrefab, new Vector3(dirtBlock.transform.position.x + 0.5f, -0.3f, dirtBlock.transform.position.z - 0.5f), Quaternion.identity, dirtBlock.transform));
        path[path.Count - 1].name = (path.Count - 1).ToString();
    }

    private void CreateTowerLocations()
    {
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                if (grid[x, z] == 0 && CanPlaceTower(x, z))
                {
                    GameObject towerArea = Instantiate(towerAreaPrefab, new Vector3(x, -0.6f, z - 0.2f), Quaternion.Euler(0, 0, 0), mapCanvasTransform);
                    Instantiate(towerWayPointPrefab, new Vector3(towerArea.transform.position.x + 0.5f, 0, towerArea.transform.position.z - 0.3f), Quaternion.identity, mapCanvasTransform);
                    Instantiate(towerButtonPrefab, new Vector3(towerArea.transform.position.x + 0.5f, 0, towerArea.transform.position.z - 0.3f), Quaternion.Euler(90, 0, 0), mapCanvasTransform);
                    grid[x, z] = 2;
                }
            }
        }
    }

    private bool CanPlaceTower(int x, int z)
    {
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
            {
                int a = x + i;
                int b = z + j;
                if (a >= 0 && a < size && b >= 0 && b < size && grid[a, b] == 1)
                    return true;
            }
        return false;
    }

    public List<GameObject> GetPath() { return path; }
}
