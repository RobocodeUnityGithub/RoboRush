using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float speedSide;
    [SerializeField] private float gravity;
    [SerializeField] private int lineToMove = 1;
    [SerializeField] private float lineDistance;
    private CharacterController characterController;
    private Animator animator;
    private Pause pause;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        pause =FindObjectOfType<Pause>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(pause.IsPause() == false)
        {
            characterController.Move(new Vector3(0, gravity, speedMove) * Time.deltaTime);

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


            if (lineToMove == 0)
            {
                targetPosition += Vector3.left * lineDistance;
            }
            else if (lineToMove == 2)
            {
                targetPosition += Vector3.right * lineDistance;
            }

            transform.position = targetPosition;
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

    }

    public void MovementSide(bool isRihht)
    {

        if (isRihht)
        {
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }
        else if (isRihht == false)
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }
    }
}
