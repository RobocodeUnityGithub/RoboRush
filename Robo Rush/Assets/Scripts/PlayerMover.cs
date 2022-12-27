using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float speedSide;
    [SerializeField] private float gravity;
    private int sideValue;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.Move(new Vector3(sideValue * speedSide, gravity, speedMove) * Time.deltaTime);
    }

    public void MovementSide(int newSideValue)
    {
        sideValue = newSideValue;
    }
}
