using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformsSpawner : PlatformsSpawner
{
    [SerializeField] private int maxCountToSpawnBust;
    [SerializeField] private Platform bustPlatform;
    private int currentCountToSpawnBust;
    private Transform playerTransform;
    private List<GameObject> activePlatforms = new List<GameObject>();

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMover>().transform;
        GenerateStart();
    }

    private void Update()
    {
        if (playerTransform.position.z > spawnDirection - (maxPlatformCount * platformLenght))
        {
            if (currentCountToSpawnBust == maxCountToSpawnBust)
            {
                SpawnPlatform(bustPlatform);
                currentCountToSpawnBust = 0;
            }
            else
            {
                SpawnPlatform(GetRandomPlatform());
                currentCountToSpawnBust++;
            }
            RemoveActivePlatforms();
        }
    }


    protected override void SpawnPlatform(Platform spawnPlatform)
    {
        GameObject newPlatform = Instantiate(spawnPlatform, transform.forward * spawnDirection, transform.rotation).gameObject;
        spawnDirection += platformLenght;
        activePlatforms.Add(newPlatform);
    }

    private void RemoveActivePlatforms()
    {
        GameObject lostPlatform = activePlatforms[0];
        activePlatforms.RemoveAt(0);
        Destroy(lostPlatform);
    }

}
