using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject creditsUI;
    public void nextLevel()
    {
        completeLevelUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        creditsUI.SetActive(true);
    }
}
