using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Class to give to obstacles to reduce the Player's life
*/
public class ObstacleManager : MonoBehaviour
{
    public GameManager gameManager; // Manages Players lifes
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.DecreaseLife();
            Destroy(gameObject);
        }
    }
}
