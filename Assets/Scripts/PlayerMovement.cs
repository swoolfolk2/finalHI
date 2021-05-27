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
    private int currentJumpStep;
    private float currentHeight;
    private Rigidbody playerRigidbody;
    private float movementSize;
    public Animator animator;
    
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
        isJumping = true;
    }
    private void Start()
    {
        currentHeight = transform.position.y;
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Jump();
        Fall();
    }
    private void Move()
    {
        if (directionToMove == Vector3.left)
        {
            if (transform.position.x > TrainGenerator.creationPositions[position] * movementSize)
            {
                transform.position += directionToMove * speed * Time.deltaTime;
            }
            else
            {
                SetPosition();
            }
        }
        else if (directionToMove == Vector3.right)
        {
            if (transform.position.x < TrainGenerator.creationPositions[position] * movementSize)
            {
                transform.position += directionToMove * speed * Time.deltaTime;
            }
            else
            {
                SetPosition();
            }
        }
    }
    private void Jump()
    {
        if (isJumping && currentJumpStep < jumpSteps)
        {
            transform.Translate(0, jumpHeight / jumpSteps, 0);
            currentJumpStep++;
            animator.SetBool("jump",true);
        }
        if (currentJumpStep == jumpSteps && playerRigidbody.velocity.y >= 0)
        {
            currentJumpStep = 0;
            isJumping = false;
             
        }
    }
    private void SetPosition()
    {
        transform.position = new Vector3(TrainGenerator.creationPositions[position] * movementSize, transform.position.y, transform.position.z);
        directionToMove = Vector3.zero;
    }
    private void Fall()
    {
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.AddForce(new Vector3(0, playerRigidbody.velocity.y * fallSpeed * Time.deltaTime, 0), ForceMode.VelocityChange);
        }
        if (movementSize == 0)
        {
            movementSize = trainGenerator.GetTrainPrefabLocalScale().x;
        }
    }
}
