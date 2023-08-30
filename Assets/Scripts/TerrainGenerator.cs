using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject dirtPrefab;
    public GameObject stonePrefab;
    public GameObject bedrockPrefab;
    public GameObject treePrefab;


    public int chunkSize = 32;
    public float noiseScale = 0.1f;
    public int terrainHeight = 10;
    public float treeSpawnChance = 0.005f;


    private void Start()
    {
        GenerateTerrain();
    }


    void GenerateTerrain()
    {
        int halfChunkSize = chunkSize / 2;

        for (int x = -halfChunkSize; x < halfChunkSize; x++)
        {
            for (int z = -halfChunkSize; z < halfChunkSize; z++)
            {
                int totalHeight = (int)(Mathf.PerlinNoise((x + halfChunkSize) * noiseScale, (z + halfChunkSize) * noiseScale) * terrainHeight);
   
                for (int y = 0; y <= totalHeight; y++)
                {
                    //Instantiate(dirtPrefab, new Vector3(x, y, z), Quaternion.identity);

                    GameObject newBlock;

                    if (y == 0)
                    {
                        newBlock = Instantiate(bedrockPrefab, new Vector3(x, y, z), Quaternion.identity);
                    }
                    else if (y == totalHeight)
                    {
                        newBlock = Instantiate(dirtPrefab, new Vector3(x, y, z), Quaternion.identity);

                        if (Random.value < treeSpawnChance)
                        {
                            GameObject newTree = Instantiate(treePrefab, new Vector3(x, y + 1, z), Quaternion.identity);
                            newTree.transform.parent = transform;
                        }
                    }
                    else
                    {
                        newBlock = Instantiate(stonePrefab, new Vector3(x, y, z), Quaternion.identity);
                    }

                    newBlock.transform.parent = this.transform;

                }
            }
        }
    }

}
