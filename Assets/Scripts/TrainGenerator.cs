using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrainGenerator : MonoBehaviour
{
    public static float[] creationPositions = { -1, 0, 1 };
    public GameManager gameManager;
    public GameObject[] trainsPrefabs;
    public ObstacleGenerator obstacleGenerator;
    private GameObject lastTrainCreated;
    private float lastSize;
    private Vector3 lastPosition = Vector3.zero;
    private Vector3 trainPrefabLocalScale;
    private GameObject trainPrefab;
    public GameObject GetLastTrainCreated()
    {
        return lastTrainCreated;
    }
    public float GetLastSize()
    {
        return lastSize;
    }
    public Vector3 GetLastPosition()
    {
        return lastPosition;
    }
    public Vector3 GetTrainPrefabLocalScale()
    {
        return trainPrefabLocalScale;
    }
    public void CreateFirstGeneration(Vector3 position, ObstacleGenerator obstacleGenerator)
    {
        lastPosition = position;
        Vector3 initialPosition = Vector3.zero;
        int index = 0;
        bool generateObstacle;
        for (int i = 0; i < 10; i++)
        {
            index = UnityEngine.Random.Range(0, trainsPrefabs.Length);
            trainPrefab = trainsPrefabs[index];
            trainPrefabLocalScale = trainPrefab.GetComponent<BoxCollider>().size;
            if (i == 0)
            {
                initialPosition = position;
                CreateNewTrain(initialPosition, new Vector3(position.x + trainPrefabLocalScale.x, position.y, position.z));
            }
            else
            {
                Vector3[] positions = GetRandomPosition();
                CreateNewTrain(positions[0], positions[1]);
                generateObstacle = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
                if (i % 3 == 0 && generateObstacle && positions[0].x != positions[1].x)
                {
                    obstacleGenerator.CreateNextGeneration(lastTrainCreated.transform);
                }
            }
        }
    }
    public void CreateNextGeneration()
    {
        trainPrefab = trainsPrefabs[UnityEngine.Random.Range(0, trainsPrefabs.Length)];
        trainPrefabLocalScale = trainPrefab.GetComponent<BoxCollider>().size;
        Vector3[] positions = GetRandomPosition();
        CreateNewTrain(positions[0], positions[1]);
    }
    private void CreateNewTrain(Vector3 positionT1, Vector3 positionT2)
    {
        GameObject newTrain = Instantiate(trainPrefab);
        newTrain.transform.position = positionT1 + Vector3.forward * trainPrefabLocalScale.z / 2;
        newTrain.GetComponent<TrainMovement>().SetGameManager(gameManager);
        lastTrainCreated = newTrain;
        lastSize = newTrain.transform.localScale.z;
        lastPosition = newTrain.transform.position + Vector3.forward * trainPrefabLocalScale.z / 2;
        GameObject newTrain2 = Instantiate(trainPrefab);
        newTrain2.transform.position = positionT2 + Vector3.forward * trainPrefabLocalScale.z / 2;
        newTrain2.GetComponent<TrainMovement>().SetGameManager(gameManager);
    }
    private Vector3[] GetRandomPosition()
    {
        int index = UnityEngine.Random.Range(0, 3);
        float newX = lastPosition.x + trainPrefabLocalScale.x * creationPositions[index];
        if (newX < trainPrefabLocalScale.x * -1 || newX > trainPrefabLocalScale.x * 1)
        {
            newX = 0;
        }
        float newX2 = newX + trainPrefabLocalScale.x;
        if (newX2 > trainPrefabLocalScale.x * 1)
        {
            newX2 = -trainPrefabLocalScale.x;
        }
        return new Vector3[] { new Vector3(newX, lastPosition.y, lastPosition.z), new Vector3(newX2, lastPosition.y, lastPosition.z), };
    }
}
