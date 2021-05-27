using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float height = 2.4f;
    public void CreateNextGeneration(Transform lastTrainTransform)
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.SetParent(lastTrainTransform);
        newObstacle.transform.localPosition = new Vector3(0, height, 0);
    }
}