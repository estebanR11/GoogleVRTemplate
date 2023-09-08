using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

}
