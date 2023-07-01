using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicCarrousel : MonoBehaviour
{
    [SerializeField] List<MusicDataSO> music;
    [SerializeField] Image leftImage;
    [SerializeField] Image midImage;
    [SerializeField] Image rightImage;
    [SerializeField] TextMeshProUGUI actualMusicName;

    [SerializeField] int actualMusicIndex;
    [SerializeField] int beforeMusicIndex;
    [SerializeField] int afterMusicIndex;

    [SerializeField] AudioSource asource;
    private void OnEnable()
    {
 
        actualMusicIndex = 0;
        SetSong(0);
    }


    public void SetSong(int newNumber)
    {
        actualMusicIndex += newNumber;
        if (actualMusicIndex < 0)
        {
            actualMusicIndex = music.Count - 1;
        }
        else if (actualMusicIndex > music.Count - 1)
        {
            actualMusicIndex = 0;
        }
        afterMusicIndex = actualMusicIndex + 1;
        beforeMusicIndex = actualMusicIndex - 1;

        if (beforeMusicIndex < 0)
        {
            beforeMusicIndex = music.Count - 1;
        }
        if (afterMusicIndex > music.Count - 1)
        {
            afterMusicIndex = 0;
        }



        if(music[beforeMusicIndex].musicSprite !=null)
        {
            leftImage.sprite = music[beforeMusicIndex].musicSprite;
        }

        if (music[afterMusicIndex].musicSprite != null)
        {
            rightImage.sprite = music[afterMusicIndex].musicSprite;
        }
 
        if(music[actualMusicIndex].musicSprite !=null)
        {
            midImage.sprite = music[actualMusicIndex].musicSprite;
        }
        actualMusicName.text = music[actualMusicIndex].musicName;
        asource.Stop();
        if (music[actualMusicIndex].musicClip!=null)
        {
            asource.clip = music[actualMusicIndex].musicClip; asource.Play();
        }  
  
 
      
  
    }

}
