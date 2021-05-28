using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject bonusPrefab;
    public float height = 2.4f;
    public GameManager gameManager;
    public void CreateNextGeneration(Transform lastTrainTransform)
    {
        GameObject newObstacle = null;
        if (System.Convert.ToBoolean(Random.Range(0, 2)) || true)
        {
            newObstacle = Instantiate(obstaclePrefab);
            height = 2.8f;
            newObstacle.GetComponent<ObstacleManager>().SetGameManager(gameManager);
        }
        else
        {
            newObstacle = Instantiate(bonusPrefab);
        }
        newObstacle.transform.SetParent(lastTrainTransform);
        newObstacle.transform.localPosition = new Vector3(0, height, 0);
    }
}