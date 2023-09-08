using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    int lvl;

    [Header("Managers")]
    [SerializeField] private SoundManager soundManager;
    AudioClip musicClip;

    [SerializeField] GameObject FadeOut;
    private void Awake(){
    

        instance = this;

    }

    public void SetNewEmojiData(EmojiDataSO newEmoji)
    {
        emojiSelectedData = newEmoji;
    }

    public void SelectLevelId(int levelid)
    {
        lvl = levelid;
    }
    public void SelectMusicId(AudioClip clip) {
        
        musicClip = clip;
        soundManager.SetAudioClip(musicClip);
    }
    public void QuitApp()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Confirm()
    {
        baseLevel.SetActive(false);
        StartCoroutine(LoadSceneSelected());
        //soundManager.SetAudio(musicId);
       // soundManager.SetAudioClip(musicClip);
    }

    IEnumerator LoadSceneSelected()
    {
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(lvl);
        


    }
}
