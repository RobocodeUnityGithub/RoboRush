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

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
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
    }

    public void MovementSide(bool isRight)
    {

        if (isRight)
        {
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }
        else if (isRight == false)
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }
    }
}