using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    static public float speed = 25;
    private GameManager gameManager;
    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    private void Update()
    {
        if (!gameManager.IsEndGameContainerActive())
        {
            Vector3 direction = Vector3.back;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
