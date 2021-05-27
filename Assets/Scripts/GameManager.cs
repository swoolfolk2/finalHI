using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TrainGenerator trainGenerator;
    public GameObject endGameContainer;
    public Text scoreText; 
    public Text endGameScoreText;
    int score = 0;
    bool isPlaying = false;
    public void EndGame()
    {
        endGameContainer.SetActive(true);
    }
    public void StartNewGame()
    {

        endGameContainer.SetActive(false);
        trainGenerator.CreateInitialGeneration();
        score = 0;
        isPlaying = true;
        scoreText.enabled = true;
    }
    public bool IsEndGameContainerActive()
    {
        
        if(endGameContainer.activeSelf){
            isPlaying = false;
            scoreText.enabled = false;
            endGameScoreText.text = scoreText.text;
        }
        return endGameContainer.activeSelf;
    }
    private void Start()
    {
        StartNewGame();

    }
    private void Update()
    {
        if(isPlaying){
            score += (int) (1);
            scoreText.text = "Score: "+score.ToString();
        }
        
    }
}
