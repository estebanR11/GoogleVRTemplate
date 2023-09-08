using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    [SerializeField] private AudioClip[] clips;

    private AudioSource audioSource;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    GameObject soundManagerObject = new GameObject("SoundManager");
                    instance = soundManagerObject.AddComponent<SoundManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Inicializa el AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void SetAudio(int id)
    {
        if (id >= 0 && id < clips.Length)
        {
            audioSource.clip = clips[id];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("ID de clip de audio no válido: " + id);
        }
    }

    public void SetAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
