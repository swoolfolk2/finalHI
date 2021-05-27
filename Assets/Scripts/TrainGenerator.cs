using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGenerator : MonoBehaviour
{
    public static float[] creationPositions = { -6.5f, 0, 6.5f };
    public GameManager gameManager;
    public ControllerManager controllerManager;
    public GameObject trainPrefab;
    public GameObject playerPrefab;
    public GameObject mainCamera;
    public int[] sizeLimits = { 30, 100 };
    private GameObject lastTrainCreated;
    private float timer = 0;
    private float lastSize = 30;
    private Vector3 lastPosition = Vector3.zero;
    public void CreateInitialGeneration()
    {
        DestroyPrefabsInstances();
        timer = 0;
        lastSize = 30;
        lastPosition = transform.position;
        Vector3 initialPosition = Vector3.zero;
        for (int i = 0; i < 10; i++)
        {
            if (i == 0)
            {
                initialPosition = transform.position;
                CreateNewTrain(initialPosition);
            }
            else
            {
                CreateNewTrain(GetRandomPosition());
            }
        }
        mainCamera.SetActive(false);
        CreatePlayer(initialPosition);
    }
    private void Update()
    {
        if (!gameManager.IsEndGameContainerActive())
        {
            timer += Time.deltaTime;
            if (timer >= lastSize / 10 / TrainMovement.speed)
            {
                timer = 0;
                CreateNewTrain(GetRandomPosition());
            }
        }
    }
    private void CreatePlayer(Vector3 position)
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        newPlayer.transform.SetParent(transform);
        newPlayer.transform.Translate(new Vector3(0, 0, 10));
        controllerManager.SetPlayerMovement(newPlayer.GetComponent<PlayerMovement>());
    }
    private void CreateNewTrain(Vector3 position)
    {
        GameObject newTrain = Instantiate(trainPrefab);
        Vector3 newTrainLocalScale = GetRandomScale();
        newTrain.transform.localScale = newTrainLocalScale;
        newTrain.transform.position = position + Vector3.forward * newTrainLocalScale.z / 2;
        newTrain.GetComponent<TrainMovement>().SetGameManager(gameManager);
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
