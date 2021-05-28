using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Class to manage the movement of the Player
*/
public class PlayerMovement : MonoBehaviour
{
    public float fallSpeed = 8; // float value of the falling speed. Simulating Gravity
    public TrainGenerator trainGenerator; // TrainGenerator to get train values
    public GameManager gameManager; // Manages Game Status
    public Animator animator; // Animator to manage player's animations
    public float height; // float value for the maximun height that user can jump
    private Vector3 _directionToMove = Vector3.zero; // Direction in which the user will move
    private bool _isJumping; // boolen if the Player is jumping
    private bool _canJump = true; // boolean if the user can jump (is grounded)
    private CharacterController _characterController; // CharacterController to move the user
    private Rigidbody _playerRigidbody; // to pause the Player's movement
    
    /**
        When pressed the jumping action button the user will jump if it can
    */
    public void ActivateIsJumping()
    {
        if (_canJump)
        {
            height = transform.position.y + 1;
            _isJumping = true;
            animator.SetBool("jump", true);
            _canJump = false;
        }

    }
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!gameManager.IsPauseContainerActive())
        {
            if (_playerRigidbody.isKinematic)
            {
                _playerRigidbody.isKinematic = false;
            }
            if (_isJumping)
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
            _playerRigidbody.isKinematic = true;
        }
    }

    /**
        Move the Player in the give [direction]
        @param direction Vector3 to determine the direction in which the player will move
    */
    public void Move(Vector3 direction)
    {
        _directionToMove = direction;
        if (direction.x == 1 || direction.x == -1)
        {
            Vector3 move = direction * trainGenerator.GetTrainPrefabLocalScale().x;
            if (transform.position.x > -trainGenerator.GetTrainPrefabLocalScale().x && direction.x == -1)
            {
                _characterController.Move(move);
            }
            else if (transform.position.x < trainGenerator.GetTrainPrefabLocalScale().x && direction.x == 1)
            {
                _characterController.Move(move);
            }
        }
        else
        {
            _characterController.Move(direction * 3f);
        }
    }

    /**
        Move the Player in a upwards direction to make a simulated jump
    */
    private void Jump()
    {
        if (transform.position.y < height)
        {
            _characterController.Move(Vector3.up * 2 * Time.deltaTime);
        }
        else
        {
            _isJumping = false;
            animator.SetBool("jump", false);

        }
    }
    /**
        Move the Player in a downwards direction to make a simulated gravity fall
    */
    private void Fall()
    {
        if (!_characterController.isGrounded && !_isJumping)
        {
            _characterController.Move(Vector3.down * fallSpeed * Time.deltaTime);
        }
        if (_characterController.velocity == Vector3.zero)
        {
            _canJump = true;
        }

    }
}
