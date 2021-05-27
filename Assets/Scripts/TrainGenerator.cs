using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGenerator : MonoBehaviour
{
    public static float[] creationPositions = { -6.5f, 0, 6.5f };
    public GameObject trainPrefab;
    public int[] sizeLimits = { 30, 100 };
    private GameObject lastTrainCreated;
    private float timer = 0;
    private float lastSize = 30;
    private Vector3 lastPosition = Vector3.zero;
    private void Start()
    {
        lastPosition = transform.position;
        for (int i = 0; i < 10; i++)
        {
            CreateNewTrain(GetRandomPosition());
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lastSize / 10 / TrainMovement.speed)
        {
            timer = 0;
            CreateNewTrain(GetRandomPosition());
        }
    }
    private void CreateNewTrain(Vector3 position)
    {
        GameObject newTrain = Instantiate(trainPrefab);
        Vector3 newTrainLocalScale = GetRandomScale();
        newTrain.transform.localScale = newTrainLocalScale;
        newTrain.transform.position = position + Vector3.forward * newTrainLocalScale.z / 2;
        lastTrainCreated = newTrain;
        lastSize = newTrain.transform.localScale.z;
        lastPosition = newTrain.transform.position + Vector3.forward * newTrainLocalScale.z / 2;
    }
    private Vector3 GetRandomScale()
    {
        int z = Random.Range(sizeLimits[0], sizeLimits[1]);
        return new Vector3(6, 9, z);
    }
    private Vector3 GetRandomPosition()
    {
        double x = Random.Range(0, 2);
        return new Vector3(creationPositions[(int)x], lastPosition.y, lastPosition.z);
    }
}
