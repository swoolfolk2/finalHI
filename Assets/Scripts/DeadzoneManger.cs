using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Class to detect if the player entered the game over zone
*/
public class DeadzoneManger : MonoBehaviour
{
    public GameManager gameManager; // GameManager to alter game status
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.EndGame();
        }
    }
}
