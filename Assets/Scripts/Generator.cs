using UnityEngine;
using System;

public class Generator : MonoBehaviour
{
    public TrainGenerator trainGenerator;
    public GameObject mainCamera;
    public PlayerGenerator playerGenerator;
    public GameManager gameManager;
    public ObstacleGenerator obstacleGenerator;
    private float timer = 0;
    private int trainCounter = 0;
    private bool generateObstacle;
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
    private void CreateNextGeneration()
    {
        timer += Time.deltaTime;
        if (timer >= trainGenerator.GetLastSize() / 10 / TrainMovement.speed)
        {
            timer = 0;
            trainGenerator.CreateNextGeneration();
            generateObstacle = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
            if (trainCounter % 3 == 0 && generateObstacle)
            {
                obstacleGenerator.CreateNextGeneration(trainGenerator.GetLastTrainCreated().transform);
            }
            trainCounter++;
        }
    }
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