using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{


  
    public void LoadScene(string name)
    {
        //name = "NextLevel1";
        Time.timeScale = 1.0f;
        //SceneManager.LoadScene(name);
        SceneManager.LoadScene(name);
       
        
    }

  
    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
    public void PlayFromMain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
