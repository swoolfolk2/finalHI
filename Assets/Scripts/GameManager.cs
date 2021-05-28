using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
    Class to manage the status of the game
*/
public class GameManager : MonoBehaviour
{
    public TrainGenerator trainGenerator; // Generate Trains Script
    public GameObject endGameContainer; // Displayed Game Over Screen
    public Generator generator; // Main Generator
    public Text scoreText; // Text to display current player Score
    public Text endGameScoreText; // Text to display player Score on Game Over Screen
    public GameObject gameContainer; // UI for when Player is playing
    public List<GameObject> lifesObjects; // UI for Health of the Player 
    public GameObject pauseContainer; // UI for Pause 
    public TextMeshProUGUI cardName; // Name on Card
    public TextMeshProUGUI cardFrom; // Name of the origin place
    private int _score = 0; // int value of the Player's score
    private bool _isPlaying = false; // boolean for knowing if Player is currently playing
    private int _lifeCounter = 3; // int value of Player's Health

    /**
        Display the Game Over Screen
    */
    public void EndGame()
    {
        endGameContainer.SetActive(true);
        gameContainer.SetActive(false);
    }
    
    /**
        Restarts the Game
    */
    public void StartNewGame()
    {
        gameContainer.SetActive(true);
        endGameContainer.SetActive(false);
        generator.CreateFirstGeneration();
        _score = 0;
        _isPlaying = true;
        scoreText.enabled = true;
        _lifeCounter = 3;
        lifesObjects.ForEach(lifeObject => lifeObject.SetActive(true));
    }
    /**
        Detects if the user is still playing or if it's Game Over
        @return bool if it's Game Over
    */
    public bool IsEndGameContainerActive()
    {
        if (endGameContainer.activeSelf)
        {
            _isPlaying = false;
            scoreText.enabled = false;
            endGameScoreText.text = scoreText.text;
        }
        return endGameContainer.activeSelf;
    }

    /**
        Reduce Player's Health by 1
    */
    public void DecreaseLife()
    {
        _lifeCounter--;
        GameObject objectFound = lifesObjects.Find(lifeObject => lifeObject.activeSelf);
        objectFound.SetActive(false);
        if (_lifeCounter == 0)
        {
            EndGame();
        }
    }
    /**
        Detects if the user is paused
        @return bool if game is paused
    */
    public bool IsPauseContainerActive()
    {
        if(pauseContainer.activeSelf){
            _isPlaying = false;
        }
        else{
            _isPlaying = true;
        }
        return pauseContainer.activeSelf;
    }
    
    private void Start()
    {
        if (GlobalControl.fields.Count == 2)
        {
            cardName.text = GlobalControl.fields[0];
            cardFrom.text = "From: " + GlobalControl.fields[1];
        }
        StartNewGame();
        pauseContainer.SetActive(false);
    }

    private void Update()
    {
        if (_isPlaying)
        {
            _score += (int)(1);
            scoreText.text = "Score: " + _score.ToString();
        }
    }
}
