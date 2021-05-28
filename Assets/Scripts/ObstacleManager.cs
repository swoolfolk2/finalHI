using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private GameManager gameManager;
    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.removeOneLife();
            Destroy(gameObject);
        }
    }
}
