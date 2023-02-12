using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public GameObject completeLevelUI;
    public void retry()
    {
        completeLevelUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void replay()
    {
        completeLevelUI.SetActive(false);
        SceneManager.LoadScene("Landing page");
    }
}
