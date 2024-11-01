using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class looseMenu : MonoBehaviour
{
  public void Retry()
    {
        SceneManager.LoadScene("CodeTest");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
