using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    public void SetAudio(int id)
    {
       AudioSource asource = GetComponent<AudioSource>();
        asource.clip = clips[id];
        asource.Play();
        
    }
}
