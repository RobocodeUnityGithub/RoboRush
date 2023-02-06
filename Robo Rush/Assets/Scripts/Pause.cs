using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    [SerializeField] private Sprite onPauseSprite;
    [SerializeField] private Sprite offPuseSprite;
    [SerializeField] private Image pauseImage;
    [SerializeField] private TMP_Text pauseText;
    private bool isPause;

    private void Start()
    {
        pauseImage.sprite = offPuseSprite;
        pauseText.text = "";
    }

    public void SetPause()
    {
        isPause = !isPause;

        if (isPause)
        {
            pauseText.text = "Pause";
            pauseImage.sprite = onPauseSprite;
        }
        else
        {
            pauseImage.sprite = offPuseSprite;
            pauseText.text = "";
        }
    }

    public bool IsPause()
    {
        return isPause;
    }

}
