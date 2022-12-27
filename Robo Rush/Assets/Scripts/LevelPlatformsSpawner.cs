using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlatformsSpawner : PlatformsSpawner
{
    [SerializeField] private Platform finalPlatform;
    private void Start()
    {
        GenerateStart();
    }
    protected override void GenerateStart()
    {
       base.GenerateStart();
       SpawnPlatform(finalPlatform);
    }

}
