using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TrainGenerator trainGenerator;
    public GameObject endGameContainer;
    public Generator generator;
    public void EndGame()
    {
        endGameContainer.SetActive(true);
    }
    public void StartNewGame()
    {
        endGameContainer.SetActive(false);
        generator.CreateFirstGeneration();
    }
    public bool IsEndGameContainerActive()
    {
        return endGameContainer.activeSelf;
    }
    private void Start()
    {
        StartNewGame();
    }
}
