using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float fallSpeed = 0;
    public TrainGenerator trainGenerator;
    public GameManager gameManager;
    private Vector3 directionToMove = Vector3.zero;
    private int position = 1;
    private bool isJumping;
    private bool canJump = true;
    private CharacterController characterController;
    private float movementSize;
    public Animator animator;
    public float height;
    private Rigidbody playerRigidbody;

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
        if (canJump)
        {
            height = transform.position.y + 1;
            isJumping = true;
            animator.SetBool("jump", true);
            canJump = false;
        }

    }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!gameManager.IsPauseContainerActive())
        {
            if (playerRigidbody.isKinematic)
            {
                playerRigidbody.isKinematic = false;
            }
            if (isJumping)
            {
                Jump();
            }
            else
            {
                Fall();
            }
        }
        else
        {
            playerRigidbody.isKinematic = true;
        }
    }
    public void Move(Vector3 direction)
    {
        directionToMove = direction;
        if (direction.x == 1 || direction.x == -1)
        {
            Vector3 move = direction * trainGenerator.GetTrainPrefabLocalScale().x;
            if (transform.position.x > -trainGenerator.GetTrainPrefabLocalScale().x && direction.x == -1)
            {
                characterController.Move(move);
            }
            else if (transform.position.x < trainGenerator.GetTrainPrefabLocalScale().x && direction.x == 1)
            {
                characterController.Move(move);
            }
        }
        else
        {
            characterController.Move(direction * 3f);
        }
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
        if (characterController.velocity == Vector3.zero)
        {
            canJump = true;
        }

    }
}
