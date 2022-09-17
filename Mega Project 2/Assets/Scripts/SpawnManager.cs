using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] SpawnPrefabs;
    private float startDelay = 2;
    private float spawnDelay = 1.5f;
    public GameObject Block;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBlocks", startDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBlocks()
    {
        
        Instantiate(Block, SpawnPrefabs[0].gameObject.transform.position, Quaternion.identity);
        Instantiate(Block, SpawnPrefabs[1].gameObject.transform.position, Quaternion.identity);
        Instantiate(Block, SpawnPrefabs[2].gameObject.transform.position, Quaternion.identity);
        Instantiate(Block, SpawnPrefabs[3].gameObject.transform.position, Quaternion.identity);
        

    }
}
