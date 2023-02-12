using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseGame : MonoBehaviour
{
    //private bool pause;
    public Timer timekeep;
    public GameObject pauseLevelUI;
    public void Pause()
    {
        if(timekeep.pause==false)
        {
            timekeep.pause = true;
            pauseLevelUI.SetActive(true);
        }
    }
}
