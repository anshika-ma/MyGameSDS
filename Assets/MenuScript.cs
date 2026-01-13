using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel;
    public void StartGame()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel.SetActive(false);
    }
    public void StartEasy()
    {
        GameSettings.CurrentDifficulty=Difficulty.Easy;
        SceneManager.LoadScene("SampleScene");
    }

    public void StartMedium()
    {
        GameSettings.CurrentDifficulty=Difficulty.Medium;
        SceneManager.LoadScene("SampleScene");
    }

    public void StartHard()
    {
        GameSettings.CurrentDifficulty=Difficulty.Hard;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void rules()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel.SetActive(true);
    }
    public void Back()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel.SetActive(false);
    }
}
    