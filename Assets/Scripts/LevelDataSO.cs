using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level Data")]
public class LevelDataSO : ScriptableObject
{
    public string levelObjectName;
    public Sprite levelIcon;
    public string levelName;
    public int id;

    public GameObject GetLevelObject()
    {
        GameObject levelObject = GameObject.Find(levelObjectName);
        return levelObject;
    }
}
