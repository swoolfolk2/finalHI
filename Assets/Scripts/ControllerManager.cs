using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public GameManager gameManager;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    private PlayerMovement playerMovement;
    public void SetPlayerMovement(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    private void Update()
    {
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
    private void KeyboardInput()
    {
        if (Input.GetKeyDown(left))
        {
            playerMovement.MoveLeft();
        }
        else if (Input.GetKeyDown(right))
        {
            playerMovement.MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.ActivateIsJumping();
        }
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