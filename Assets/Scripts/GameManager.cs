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
    public GameObject lifesContainer;
    private int score = 0;
    private bool isPlaying = false;
    private int lifes;
    public List<GameObject> lifesObjects;

    public void EndGame()
    {
        endGameContainer.SetActive(true);
        gameContainer.SetActive(false);
    }
    public void StartNewGame()
    {
        generator.CreateFirstGeneration();
        score = 0;
        isPlaying = true;
        scoreText.enabled = true;
        lifes = 3;
        foreach (GameObject lifeObject in lifesObjects)
        {
            lifeObject.SetActive(true);
        }
        endGameContainer.SetActive(false);
        gameContainer.SetActive(true);
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
    public void removeOneLife()
    {
        lifes--;
        GameObject objectFound = lifesObjects.Find(lifeObject => lifeObject.activeSelf == true);
        objectFound.SetActive(false);
        if (lifes == 0)
        {
            EndGame();
        }
    }
    private void Start()
    {
        StartNewGame();
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
