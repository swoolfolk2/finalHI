using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public GameManager gameManager = null;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public PlayerMovement playerMovement;
    public void SetPlayerMovement(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    private void Update()
    {
        if(!gameManager)
        {
            KeyboardInput();
        }else{
            if (!gameManager.IsEndGameContainerActive())
            {
                
                KeyboardInput();
                JoystickInput();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    gameManager.StartNewGame();
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameManager.StartNewGame();
                }

            }
        }
        
    }
    private void KeyboardInput()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKeyDown(left))
        {
            direction += Vector3.left;
        }
        else if (Input.GetKeyDown(right))
        {
            direction += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.ActivateIsJumping();
            
        }
        playerMovement.Move(direction);
    }
    private void JoystickInput()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            playerMovement.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            playerMovement.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            playerMovement.ActivateIsJumping();
        }
    }
}