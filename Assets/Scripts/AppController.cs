using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
    [SerializeField] int buildIndex;
    public void QuitApp()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetActualLevel()
    {
        SceneManager.LoadScene(buildIndex);

    }

}
