using UnityEngine;
/**
    Class to detect Joystick inputs from a Controller
*/
public class ControllerManager : MonoBehaviour
{
    public GameManager gameManager = null; // GameManager to detect status of game
    public KeyCode left = KeyCode.A; // Key for left movement
    public KeyCode right = KeyCode.D; // Key for right movement
    public PlayerMovement playerMovement; // Script to move player

    private void Update()
    {
        if (!gameManager)
        {
            KeyboardInput();
        }
        else
        {
            if (!gameManager.IsEndGameContainerActive() && !gameManager.IsPauseContainerActive())
            {
                KeyboardInput();
                JoystickInput();
            }
            if (gameManager.IsEndGameContainerActive())
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
            if (gameManager.IsPauseContainerActive())
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    gameManager.ContinueGame();
                }
            }
        }

    }
    /**
        Function to detect Keyboard Input and move Player
    */
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
    /**
        Function to detect Joystick Input and move Player
    */
    private void JoystickInput()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            direction += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            direction += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            playerMovement.ActivateIsJumping();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            gameManager.PauseGame();
        }
        playerMovement.Move(direction);
    }
}