using UnityEngine;

/**
    Class to create new Player
*/
public class PlayerGenerator : MonoBehaviour
{
    public GameObject playerPrefab; // Player's Prefab
    public ControllerManager controllerManager; // Manages Controller's Input
    public GameManager gameManager; // Manages Game's Status

    /**
        Method to create a New Player when Game Restarts
        @param transform The parent for the Player's Object
        @param trainGenerator TrainGenerator to give to Player Movement
    */    
    public void CreatePlayer(Transform transform, TrainGenerator trainGenerator)
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        newPlayer.transform.SetParent(transform);
        newPlayer.transform.localPosition = new Vector3(0, 1.9f, 3);
        controllerManager.playerMovement = newPlayer.GetComponent<PlayerMovement>();
        PlayerMovement newPlayerPlayerMovement = newPlayer.GetComponent<PlayerMovement>();
        newPlayerPlayerMovement.trainGenerator = trainGenerator;
        newPlayerPlayerMovement.gameManager = gameManager;
    }
}