using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Newtonsoft.Json.Bson;
using UnityEngine.Audio;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    //[SerializeField] private Text uiText;
    [SerializeField] public TMP_Text uiText;

    public int Duration;
    public int remDuration;
    public GM gameManager;
    public bool pause;
    public bool startTimer = false;
    public GameObject pauseButton;
    public GameObject tickTock;


    private void Start()
    {
        begin(Duration);
    }
    
    private void begin(int Second)
    {
        remDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
            while (remDuration >= 0 && gameManager.gameHasEnded == false)
            {
                if (!pause && startTimer == true)
                {
                    uiText.text = $"{remDuration / 60:00} : {remDuration % 60:00}";
                    uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remDuration);
                    FindObjectOfType<AudioManager>().Play("tick");
                    remDuration--;
                    yield return new WaitForSeconds(1f);
                    
                    //gameManager.gameHasEnded = true;
                }
                yield return null;
            }
            OnEnd();
    }

    private void OnEnd()
    {
        Debug.Log("Time End");
        //FindObjectOfType<GM>().EndGame();
        gameManager.EndGameTimer();
    }
}
