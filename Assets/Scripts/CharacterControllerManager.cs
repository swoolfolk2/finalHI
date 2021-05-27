using UnityEngine;

public class CharacterControllerManager : MonoBehaviour
{
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public PlayerMovement playerMovement;
    private void Update()
    {
        KeyboardInput();
    }
    private void KeyboardInput()
    {
        if (Input.GetKeyDown(left))
        {
            Debug.Log("KeyPressed");
            playerMovement.MoveLeft();
        }
        else if (Input.GetKeyDown(right))
        {
            Debug.Log("KeyPressed");
            playerMovement.MoveRight();
        }
    }
    private void JoystickInput()
    {

    }
}