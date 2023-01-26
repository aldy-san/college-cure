using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    GameManager gameManager;
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement pm;
    [HideInInspector]public GameObject currentChunk;

    [Header("Optimazition")]
    [HideInInspector]public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist;
    float opDist;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();
        terrainChunks = gameManager.levelData.levels[gameManager.currentLevel - 1].terrains;
        GameObject firstChunk = Instantiate(terrainChunks[0], new Vector2(0,0), Quaternion.identity);
        firstChunk.transform.parent = transform;
        spawnedChunks.Add(firstChunk);
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunksOptimizer();
    }
    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }
        if (pm.moveDir.x > 0 ) // right
        {
            if (CheckCircle("Right"))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
            if (CheckCircle("Right Top"))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Top").position;
                SpawnChunk();
            }
            if (CheckCircle("Right Down"))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }
        if (pm.moveDir.x < 0 ) // left
        {
            if (CheckCircle("Left"))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
            if (CheckCircle("Left Top"))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Top").position;
                SpawnChunk();
            }
            if (CheckCircle("Left Down"))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
        if (pm.moveDir.y > 0) // top
        {
            if (CheckCircle("Top"))
            {
                noTerrainPosition = currentChunk.transform.Find("Top").position;
                SpawnChunk();
            }
            if (CheckCircle("Right Top"))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Top").position;
                SpawnChunk();
            }
            if (CheckCircle("Left Top"))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Top").position;
                SpawnChunk();
            }
        }
        if (pm.moveDir.y < 0) // down
        {
            if (CheckCircle("Down"))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
            if (CheckCircle("Right Down"))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
            if (CheckCircle("Left Down"))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
    }
    bool CheckCircle(string direction)
    {
        return !Physics2D.OverlapCircle(currentChunk.transform.Find(direction).position, checkerRadius, terrainMask);
    }
    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        latestChunk.transform.parent = transform;
        spawnedChunks.Add(latestChunk);
    }
    void ChunksOptimizer()
    {
        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }else
            {
                chunk.SetActive(true);
            }
        }
    }
}
