using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 100f;
    public float jumpHeight = 5;
    public float jumpSteps = 60;
    public float fallSpeed = 0;
    public TrainGenerator trainGenerator;
    private Vector3 directionToMove = Vector3.zero;
    private int position = 1;
    private bool isJumping;
    private CharacterController characterController;
    private int currentJumpStep;
    private float currentHeight;
    private float movementSize;
    public Animator animator;
    
    private Vector3 moveDirection = Vector3.zero;

    public float height;

    public void SetTrainGenerator(TrainGenerator trainGenerator)
    {
        this.trainGenerator = trainGenerator;
    }
    public void MoveLeft()
    {
        if (position > 0)
        {
            position -= 1;
            directionToMove = Vector3.left;
        }
    }
    public void MoveRight()
    {
        if (position < 2)
        {
            position += 1;
            directionToMove = Vector3.right;
        }
    }
    public void ActivateIsJumping()
    {
        height = transform.position.y + 1;
        isJumping = true;
        animator.SetBool("jump", true);
    }
    private void Start()
    {
        currentHeight = transform.position.y;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isJumping)
        {
            Jump();
        }
        else
        {
            Fall();
        }
    }
    public void Move(Vector3 direction)
    {
        directionToMove = direction;
        characterController.Move(direction * 3f);

    }
    private void Jump()
    {
        if (transform.position.y < height)
        {
            characterController.Move(Vector3.up * 2 * Time.deltaTime);
        }
        else
        {
            isJumping = false;
            animator.SetBool("jump", false);
        }
    }
    private void SetPosition()
    {

        transform.position = new Vector3(TrainGenerator.creationPositions[position] * movementSize, transform.position.y, transform.position.z);
        directionToMove = Vector3.zero;
    }
    private void Fall()
    {
        if (!characterController.isGrounded && !isJumping)
        {
            characterController.Move(Vector3.down * fallSpeed * Time.deltaTime);
        }

    }
}
