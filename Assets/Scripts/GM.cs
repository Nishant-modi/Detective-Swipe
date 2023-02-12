using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public bool gameHasEnded = true;
    public float waitTime = 0.1f;
    public bool[] swipeData;
    private int index;

    public Timer t;
    [SerializeField] public TMP_Text timerText;

    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            //Invoke("Restart", waitTime);

            gameOverUI.SetActive(true);
        }
    }

    public void EndGameTimer()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            //Invoke("Restart", waitTime);

            gameOverUI.SetActive(true);
        }
    }

    public void NextLevel()
    {
        if (gameHasEnded == false)
        {
            int timeLeft = t.Duration - t.remDuration;
            gameHasEnded = true;
            Debug.Log("Next Level"+timeLeft);
            timerText.text = $"{timeLeft} Seconds";
            completeLevelUI.SetActive(true);
        }  
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Data(bool L)
    {
        //bool cardMoved = FindObjectOfType<swipe>().swipeL;
        Debug.Log("card swiped " + L);
        int intro = 0;

        if (L == swipeData[index++])
        {          
            gameHasEnded = false;
            t.startTimer = true;
            return;
            
        }
        else
        {
            //gameOverUI.SetActive(true);
            EndGame();
        }
    }
}
