using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneManger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.EndGame();
        }
    }
}
