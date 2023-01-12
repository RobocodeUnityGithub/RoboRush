using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void AddBustLevel()
    {
        FindObjectOfType<LevelBust>().AddBust();
    }
}
