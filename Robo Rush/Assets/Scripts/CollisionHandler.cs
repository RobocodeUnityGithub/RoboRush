using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private int indexMainScene;
    [SerializeField] private float loadDelayCrash = 1f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Crash()
    {
        animator.SetTrigger("Die");
        GetComponent<PlayerMover>().enabled = false;
        GetComponentInChildren<PlayerShooting>().enabled = false;
        FindObjectOfType<ScoreCounter>().CantCount();
        Invoke("LoadMainScene", loadDelayCrash);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<Enemy>() != null)
        {
            hit.gameObject.GetComponent<Enemy>().Attack();
            Crash();
        }
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(indexMainScene);
    }
}
