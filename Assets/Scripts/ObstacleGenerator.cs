using UnityEngine;

/**
    Class to generate obstacles
*/
public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab; //Prefab for the obstables
    public GameManager gameManager; // Manager for game status
    public float height = 2.4f; // float value to generate the obstales at given height

    /**
        Generate the next generation of obstacles above the train
        @param lastTrainTransform Transform of the last train generated
    */
    public void CreateNextGeneration(Transform lastTrainTransform)
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.SetParent(lastTrainTransform);
        newObstacle.transform.localPosition = new Vector3(0, height, 0);
        ObstacleManager obstacleManager = newObstacle.GetComponent<ObstacleManager>();
        obstacleManager.gameManager = gameManager;
    }
}