using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float fallSpeed = 0;
    public TrainGenerator trainGenerator;
    private Vector3 directionToMove = Vector3.zero;
    private int position = 1;
    private bool isJumping;
    private bool canJump = true;
    private CharacterController characterController;
    private float movementSize;
    public Animator animator;
    
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
        if(canJump){
            height = transform.position.y + 1;
            isJumping = true;
            animator.SetBool("jump",true);
            canJump = false;
        }
        
    }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(isJumping){
            Jump();
        }else{
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
        if(transform.position.y < height){
            characterController.Move(Vector3.up * 2 * Time.deltaTime);
        }
        else{
            isJumping = false;
            animator.SetBool("jump",false);
            
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
        if(characterController.velocity == Vector3.zero){
            canJump = true;
        }
       
    }
}
