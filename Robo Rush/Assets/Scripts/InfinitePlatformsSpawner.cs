using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformsSpawner : PlatformsSpawner
{
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
            SpawnPlatform(GetRandomPlatform());
            Debug.Log("f");
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
