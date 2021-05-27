using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGenerator : MonoBehaviour
{
    public static float[] creationPositions = { -1, 0, 1 };
    public GameManager gameManager;
    public ControllerManager controllerManager;
    public GameObject playerPrefab;
    public GameObject mainCamera;
    public GameObject[] trainsPrefabs;
    private GameObject lastTrainCreated;
    private float timer = 0;
    private float lastSize = 30;
    private Vector3 lastPosition = Vector3.zero;
    private Vector3 trainPrefabLocalScale;
    private GameObject trainPrefab;
    public Vector3 GetTrainPrefabLocalScale()
    {
        return trainPrefabLocalScale;
    }
    public void CreateInitialGeneration()
    {
        PlayerMovement playerPrefabPlayerMovement = playerPrefab.GetComponent<PlayerMovement>();
        playerPrefabPlayerMovement.trainGenerator = this;
        DestroyPrefabsInstances();
        timer = 0;
        lastSize = 30;
        lastPosition = transform.position;
        Vector3 initialPosition = Vector3.zero;
        int index = 0;
        for (int i = 0; i < 10; i++)
        {
            index = Random.Range(0, trainsPrefabs.Length);
            trainPrefab = trainsPrefabs[index];
            trainPrefabLocalScale = trainPrefab.GetComponent<BoxCollider>().size;
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
        newPlayer.transform.Translate(new Vector3(0, 0, 4));
        controllerManager.SetPlayerMovement(newPlayer.GetComponent<PlayerMovement>());
        PlayerMovement newPLayerPlayerMovement = newPlayer.GetComponent<PlayerMovement>();
    }
    private void CreateNewTrain(Vector3 position)
    {
        GameObject newTrain = Instantiate(trainPrefab);
        newTrain.transform.position = position + Vector3.forward * trainPrefabLocalScale.z / 2;
        newTrain.GetComponent<TrainMovement>().SetGameManager(gameManager);

        lastTrainCreated = newTrain;
        lastSize = newTrain.transform.localScale.z;
        lastPosition = newTrain.transform.position + Vector3.forward * trainPrefabLocalScale.z / 2;
    }
    private Vector3 GetRandomPosition()
    {
        int index = Random.Range(0, 3);
        float newX = lastPosition.x + trainPrefabLocalScale.x * creationPositions[index];
        if (newX < trainPrefabLocalScale.x * -1 || newX > trainPrefabLocalScale.x * 1)
        {
            newX = 0;
        }
        return new Vector3(newX, lastPosition.y, lastPosition.z);
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
