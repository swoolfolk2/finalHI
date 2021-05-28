using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TrainGenerator trainGenerator;
    public GameObject endGameContainer;
    public Generator generator;
    public Text scoreText;
    public Text endGameScoreText;
    public GameObject gameContainer;
    public List<GameObject> lifesObjects;
    public GameObject pauseContainer;
    private int score = 0;
    private bool isPlaying = false;
    private int lifeCounter = 3;

    public void EndGame()
    {
        endGameContainer.SetActive(true);
        gameContainer.SetActive(false);
    }
    public void StartNewGame()
    {
        gameContainer.SetActive(true);
        endGameContainer.SetActive(false);
        generator.CreateFirstGeneration();
        score = 0;
        isPlaying = true;
        scoreText.enabled = true;
        lifeCounter = 3;
        lifesObjects.ForEach(lifeObject => lifeObject.SetActive(true));
    }
    public bool IsEndGameContainerActive()
    {
        if (endGameContainer.activeSelf)
        {
            isPlaying = false;
            scoreText.enabled = false;
            endGameScoreText.text = scoreText.text;
        }
        return endGameContainer.activeSelf;
    }
    public void DecreaseLife()
    {
        lifeCounter--;
        GameObject objectFound = lifesObjects.Find(lifeObject => lifeObject.activeSelf);
        objectFound.SetActive(false);
        if (lifeCounter == 0)
        {
            EndGame();
        }
    }
    public bool IsPauseContainerActive()
    {
        return pauseContainer.activeSelf;
    }
    public void ContinueGame()
    {
        gameContainer.SetActive(true);
        pauseContainer.SetActive(false);
    }
    public void PauseGame()
    {
        gameContainer.SetActive(false);
        pauseContainer.SetActive(true);
    }
    private void Start()
    {
        StartNewGame();
        pauseContainer.SetActive(false);
    }

    private void Update()
    {
        if (isPlaying)
        {
            score += (int)(1);
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
