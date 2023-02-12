using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    
    public Timer timekeep;
    public GameObject pauseLevelUI;
    public void resume()
    {
        if (timekeep.pause == true)
        {
            timekeep.pause = false;
            pauseLevelUI.SetActive(false);
        }
    }
}
