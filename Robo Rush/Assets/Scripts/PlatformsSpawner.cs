using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] protected Platform[] platforms;
    [SerializeField] protected Platform startPlatform;
    [SerializeField] protected int maxPlatformCount;
    [SerializeField] protected float platformLenght;// в нашій грі довжина всі платформу буде однаковою
    protected float spawnDirection;

    protected virtual void SpawnPlatform(Platform spawnPlatform)
    {
        GameObject newPlatform = Instantiate(spawnPlatform, transform.forward * spawnDirection, transform.rotation).gameObject;
        spawnDirection += platformLenght;
    }

    protected Platform GetRandomPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Length);
        return platforms[randomIndex];
    }


    protected virtual void GenerateStart()
    {
        SpawnPlatform(startPlatform);
        for (int i = 0; i < maxPlatformCount; i++)
        {
            SpawnPlatform(GetRandomPlatform());
        }
    }
}
