using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int indexLevelScene;
    [SerializeField] private int indexInfiniteScene;
    private void SetActivScene(int activSceneIndx)
    {
        SceneManager.LoadScene(activSceneIndx);
    }

    public void ActiveLevelScene()
    {
        SetActivScene(indexLevelScene);
    }

    public void ActiveInfiniteScene()
    {
        SetActivScene(indexInfiniteScene);
    }
}
