using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public GameObject playerPrefab;
    public ControllerManager controllerManager;
    public void CreatePlayer(Transform transform, TrainGenerator trainGenerator)
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        newPlayer.transform.SetParent(transform);
        newPlayer.transform.localPosition = new Vector3(0, 1.9f, 4);
        controllerManager.SetPlayerMovement(newPlayer.GetComponent<PlayerMovement>());
        PlayerMovement newPLayerPlayerMovement = newPlayer.GetComponent<PlayerMovement>();
        newPLayerPlayerMovement.SetTrainGenerator(trainGenerator);
    }
}