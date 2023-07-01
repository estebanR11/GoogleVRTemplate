using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance => instance;

    [SerializeField] EmojiDataSO emojiSelectedData;

    [Header("Canvases")]
    [SerializeField] private GameObject startingCanvas;

    [Header("UIs")]
  
    [SerializeField] private GameObject initialEmotionid;
    [SerializeField] private GameObject customUI;


    [Header("Levels")]
    [SerializeField] private GameObject[] levelPicked;
    [SerializeField] private GameObject baseLevel;

    [Header("Managers")]
    [SerializeField] private SoundManager soundManager;

    private void Awake(){
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetNewEmojiData(EmojiDataSO newEmoji)
    {
        emojiSelectedData = newEmoji;
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
}
