using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TrainGenerator trainGenerator;
    public GameObject endGameContainer;
    public void EndGame()
    {
        endGameContainer.SetActive(true);
    }
    public void StartNewGame()
    {
        endGameContainer.SetActive(false);
        trainGenerator.CreateInitialGeneration();
    }
    public bool IsEndGameContainerActive()
    {
        return endGameContainer.activeSelf;
    }
    private void Start()
    {
        StartNewGame();
    }
    private void Update()
    {

    }
}
