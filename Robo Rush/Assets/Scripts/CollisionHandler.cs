using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private int indexMainScene;
    [SerializeField] private float loadDelayCrash = 1f;
    [SerializeField] private float loadDelayWin = 1f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void StopPlayer()
    {
        GetComponent<PlayerMover>().enabled = false;
        GetComponentInChildren<PlayerShooting>().enabled = false;
        FindObjectOfType<ScoreCounter>().CantCount();
    }

    private void Crash()
    {
        animator.SetTrigger("Die");
        StopPlayer();
        Invoke("LoadMainScene", loadDelayCrash);
    }

    private void Win()
    {
        animator.SetTrigger("Win");
        StopPlayer();
        Invoke("LoadMainScene", loadDelayWin);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<Enemy>() != null)
        {
            hit.gameObject.GetComponent<Enemy>().Attack();
            Crash();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Finish>() != null)
        {
            Win();
            other.gameObject.GetComponent<Finish>().AddBustLevel();
        }
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(indexMainScene);
    }
}
