using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Music", menuName = "Music Data")]
public class MusicDataSO : ScriptableObject
{
    public AudioClip musicClip;
    public string musicName;
    public Sprite musicSprite;
}
