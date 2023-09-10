using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guide Data", menuName = "New Guide Data")]

public class GuidesDataConfig : ScriptableObject
{
    public AudioClip Clip;
    public List<GuideTextData> Data;

    public GuideTextData GetDataByIndex(int index)
    {
        return Data[index];
    }

    public int GetCountData()
    {
        return Data.Count;
    }

}

[System.Serializable]
public class GuideTextData
{
    public float TimeExecute;
    [TextArea(1,2)]
    public string Guide;
    public GuideEvents Event;
}

public enum GuideEvents
{
    Nothing,
    InstructorStart,
    InstructorEnd,
    CloseEyes,
    OpenEyes,
}
