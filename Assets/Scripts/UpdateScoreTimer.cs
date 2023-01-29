using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScoreTimer : MonoBehaviour
{
    // variable for GameUIs
    private GameObject _gameUI;
    private GameObject _gameOverUI;
    private GameObject _canvas01UI;

    // variables for score
    private Text giftCountUI;
    public string scoreText = "GIFTS: ";
    private int currentScore = 0;
    public int addScore = 1;
    public int winScore = 10;

    // variables for timer
    private Text timerUI;
    public string timerText = "TIME: ";
    public float countRemaining = 90f;
    private bool countingDown = true;

    // variables for result ui
    private Text resultUI;
    public string resultLost = "You lost!";
    public string resultWin = "You won!";

    // variables for game over
    public bool gameOver;
    private bool gameWon;
    private bool gameLost;

    //variables for enemies
    public int destroyedEnemies;



    void Start()
    {

        _canvas01UI = GameObject.Find("Canvas01");
        _gameUI = GameObject.Find("Game");
        _gameOverUI = GameObject.Find("GameOver");

        giftCountUI = GameObject.Find("GiftCount").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        resultUI = GameObject.Find("Result").GetComponent<Text>();

        _canvas01UI.SetActive(true);
        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }

    void Update()
    {
        CountdownTimer();

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    currentScore += addScore;
        //    giftCountUI.text = scoreText + currentScore.ToString();
        //}

        //if(Input.GetKeyDown(KeyCode.R) && gameOver)
        //{
        //    SceneManager.LoadScene(0);
        //}
        

    }


    private void CountdownTimer()
    {
        if(countingDown)
        {
            if(countRemaining > 0)
            {
                countRemaining -= Time.deltaTime;
                timerUI.text = timerText + Mathf.Round(countRemaining).ToString();
            }
            else 
            {
                countRemaining = 0;
                timerUI.text = timerText + countRemaining.ToString();
                countingDown = false;

                CheckGameOver();
            }
        }
    }



    private void CheckGameOver()
    {
        // GameOver WIN
        if(currentScore >= winScore && !countingDown)
        {
            gameWon = true;
            gameOver = true;

            StartCoroutine(GameOver());

            //resultUI.text = resultWin;
            //resultUI.color = Color.green;
        }
        // GameOver LOST
        else if(currentScore < winScore && !countingDown)
        {
            gameLost = true;
            gameOver = true;

            StartCoroutine(GameOver());

            //resultUI.text = resultLost;
            //resultUI.color = Color.red;
        }

        // Change the UI to display the GameOver screen...
        //if(gameOver)
        //{
        //  _gameUI.SetActive(false);
        //  _gameOverUI.SetActive(true);

           
        //}

        // Coroutine, when game over is true. Display UI after x seconds delay
        IEnumerator GameOver()
        {
            yield return new WaitForSeconds(2f);

            if (gameWon)
            {
                resultUI.text = resultWin;
                resultUI.color = Color.green;
            }
            else if (gameLost)
            {
                resultUI.text = resultLost;
                resultUI.color = Color.red;
            }

            _canvas01UI.SetActive(true);
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(true);

        }

    }


}