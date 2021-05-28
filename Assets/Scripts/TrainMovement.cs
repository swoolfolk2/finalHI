using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Class to manage the trains movement
*/
public class TrainMovement : MonoBehaviour
{
    static public float speed = 20f; // float value of the speed of trains
    private GameManager _gameManager; // Manages Game's Status

    /**
        Encapsulated method to set [_gameManager]
        @param gameManager Gamemanager to be set
    */
    public void SetGameManager(GameManager gameManager)
    {
        this._gameManager = gameManager;
    }
    private void Update()
    {
        if (!_gameManager.IsEndGameContainerActive() && !_gameManager.IsPauseContainerActive())
        {
            Vector3 direction = Vector3.back;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
