using UnityEngine;
using System;

/**
    Class to manage all Generators of Objects, such as Trains, Obstacles and Player
*/
public class Generator : MonoBehaviour
{
    public TrainGenerator trainGenerator; // Generates random Trains
    public GameObject mainCamera; // Main Camera Object 
    public PlayerGenerator playerGenerator; // Generates the player to the starting position
    public GameManager gameManager; // Manages Game status
    public ObstacleGenerator obstacleGenerator; // Generates random Objects as obstacles
    private float _timer = 0; // timer to detect when to create new trains
    private int _trainCounter = 0; // counter of number of trains generated 
    private bool _generateObstacle; // If it must generate obstacle or not

    /**
        Generates the first generation of the level
    */
    public void CreateFirstGeneration()
    {
        DestroyPrefabsInstances();
        mainCamera.SetActive(false);
        trainGenerator.CreateFirstGeneration(transform.position, obstacleGenerator);
        playerGenerator.CreatePlayer(transform, trainGenerator);
    }
    private void Update()
    {
        if (!gameManager.IsEndGameContainerActive())
        {
            CreateNextGeneration();
        }
    }

    /**
        Generates the next generation of the level
    */
    private void CreateNextGeneration()
    {
        _timer += Time.deltaTime;
        if (_timer >= trainGenerator.GetLastSize() / 10 / TrainMovement.speed)
        {
            _timer = 0;
            trainGenerator.CreateNextGeneration();
            _generateObstacle = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
            if (_trainCounter % 3 == 0 && _generateObstacle)
            {
                obstacleGenerator.CreateNextGeneration(trainGenerator.GetLastTrainCreated().transform);
            }
            _trainCounter++;
        }
    }

    /**
        Destroys all objects
    */
    private void DestroyPrefabsInstances()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        GameObject[] trains = GameObject.FindGameObjectsWithTag("Train");
        foreach (GameObject train in trains)
        {
            Destroy(train);
        }
    }
}