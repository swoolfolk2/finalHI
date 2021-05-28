using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
    Class to generated Trains with a procedural method
*/
public class TrainGenerator : MonoBehaviour
{
    public static float[] creationPositions = { -1, 0, 1 }; // positions in which the trains can be generated
    public GameManager gameManager; // Manages Game Status
    public GameObject[] trainsPrefabs; // All Trains variable prefabs
    private GameObject _lastTrainCreated; // GameObject of the last train generated
    private float _lastSize; // float value of the last train's size
    private Vector3 _lastPosition = Vector3.zero; // Vector3 of the last position created
    private Vector3 _trainPrefabLocalScale; // trains scale
    private GameObject _trainPrefab; // Train prefab

    /**
        Encapsulated method to get the last train generated
    */
    public GameObject GetLastTrainCreated()
    {
        return _lastTrainCreated;
    }

    /**
        Encapsulated method to get the last train's size
    */
    public float GetLastSize()
    {
        return _lastSize;
    }
    /**
        Encapsulated method to get the train scale
    */
    public Vector3 GetTrainPrefabLocalScale()
    {
        return _trainPrefabLocalScale;
    }

    /**
        Create the first generation of randomly created trains
    */
    public void CreateFirstGeneration(Vector3 position, ObstacleGenerator obstacleGenerator)
    {
        _lastPosition = position;
        Vector3 initialPosition = Vector3.zero;
        int index = 0;
        bool generateObstacle;
        for (int i = 0; i < 10; i++)
        {
            index = UnityEngine.Random.Range(0, trainsPrefabs.Length);
            _trainPrefab = trainsPrefabs[index];
            _trainPrefabLocalScale = _trainPrefab.GetComponent<BoxCollider>().size;
            if (i == 0)
            {
                initialPosition = position;
                CreateNewTrain(initialPosition, new Vector3(position.x + _trainPrefabLocalScale.x, position.y, position.z));
            }
            else
            {
                Vector3[] positions = GetRandomPosition();
                CreateNewTrain(positions[0], positions[1]);
                generateObstacle = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
                if (i % 3 == 0 && generateObstacle && positions[0].x != positions[1].x)
                {
                    obstacleGenerator.CreateNextGeneration(_lastTrainCreated.transform);
                }
            }
        }
    }
    /**
        Create the next generation of randomly created trains
    */
    public void CreateNextGeneration()
    {
        _trainPrefab = trainsPrefabs[UnityEngine.Random.Range(0, trainsPrefabs.Length)];
        _trainPrefabLocalScale = _trainPrefab.GetComponent<BoxCollider>().size;
        Vector3[] positions = GetRandomPosition();
        CreateNewTrain(positions[0], positions[1]);
    }

    /**
        Create train with random generated values
        @param positionT1 position to generate the first new train
        @param positionT2 position to generate the second new train
    */
    private void CreateNewTrain(Vector3 positionT1, Vector3 positionT2)
    {
        GameObject newTrain = Instantiate(_trainPrefab);
        newTrain.transform.position = positionT1 + Vector3.forward * _trainPrefabLocalScale.z / 2;
        newTrain.GetComponent<TrainMovement>().SetGameManager(gameManager);
        _lastTrainCreated = newTrain;
        _lastSize = newTrain.transform.localScale.z;
        _lastPosition = newTrain.transform.position + Vector3.forward * _trainPrefabLocalScale.z / 2;
        GameObject newTrain2 = Instantiate(_trainPrefab);
        newTrain2.transform.position = positionT2 + Vector3.forward * _trainPrefabLocalScale.z / 2;
        newTrain2.GetComponent<TrainMovement>().SetGameManager(gameManager);
    }

    /**
        Generate random values for new positions
        @return new Vector3 with 2 new positions in x
    */
    private Vector3[] GetRandomPosition()
    {
        int index = UnityEngine.Random.Range(0, 3);
        float newX = _lastPosition.x + _trainPrefabLocalScale.x * creationPositions[index];
        if (newX < _trainPrefabLocalScale.x * -1 || newX > _trainPrefabLocalScale.x * 1)
        {
            newX = 0;
        }
        float newX2 = newX + _trainPrefabLocalScale.x;
        if (newX2 > _trainPrefabLocalScale.x * 1)
        {
            newX2 = -_trainPrefabLocalScale.x;
        }
        return new Vector3[] { new Vector3(newX, _lastPosition.y, _lastPosition.z), new Vector3(newX2, _lastPosition.y, _lastPosition.z), };
    }
}
