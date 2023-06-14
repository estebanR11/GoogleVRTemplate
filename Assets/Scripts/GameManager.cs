using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance => instance;


    int emotionId;
    int levelId=-1;
    int musicId =-1;

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

    public void SetEmotionId(int id)
    {
        emotionId = id;
        initialEmotionid.SetActive(false);
        customUI.SetActive(true);
    }

    public void SetLevelId(int id)
    {
        levelId = id;
        if(musicId != -1)
        {
            customUI.SetActive(false);
        }
        levelPicked[levelId].SetActive(true);
        baseLevel.SetActive(false);
    }

    public void SetMusicId(int id)
    {
        musicId = id;
        if (levelId != -1)
        {
            customUI.SetActive(false);
        }
        soundManager.SetAudio(musicId);
    }
}
