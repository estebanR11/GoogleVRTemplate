using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LevelCarrousel : MonoBehaviour
{
    [SerializeField] List<LevelDataSO> levels;
    [SerializeField] private List<GameObject> levelObjectsList;
    [SerializeField] private GameObject defaultLevel;
    [SerializeField] Image leftImage;
    [SerializeField] Image midImage;
    [SerializeField] Image rightImage;
    [SerializeField] TextMeshProUGUI actualLevelName;

    [SerializeField] int actualLevelIndex;
    [SerializeField] int beforeLevelIndex;
    [SerializeField] int afterLevelIndex;

    private void OnEnable()
    {
        defaultLevel.SetActive(false);
        actualLevelIndex = 0;
        SetLevel(0);
    }


    public void SetLevel(int newNumber)
    {
        actualLevelIndex += newNumber;
        if (actualLevelIndex < 0)
        {
            actualLevelIndex = levels.Count - 1;
        }
        else if (actualLevelIndex > levels.Count - 1)
        {
            actualLevelIndex = 0;
        }
        afterLevelIndex = actualLevelIndex + 1;
        beforeLevelIndex = actualLevelIndex - 1;

        if (beforeLevelIndex < 0)
        {
            beforeLevelIndex = levels.Count - 1;
        }
        if (afterLevelIndex > levels.Count - 1)
        {
            afterLevelIndex = 0;
        }


        leftImage.sprite = levels[beforeLevelIndex].levelIcon;
        rightImage.sprite = levels[afterLevelIndex].levelIcon;
        midImage.sprite = levels[actualLevelIndex].levelIcon;
        actualLevelName.text = levels[actualLevelIndex].levelName;
        for(int i =0;i<levelObjectsList.Count;i++)
        {
            if (i!=actualLevelIndex)
            {

                levelObjectsList[i].SetActive(false);}
            else
            {
                levelObjectsList[i].SetActive(true);
            }
        }

    }


    public void SendEmojiData()
    {
       // GameManager.Instance.SetNewEmojiData(emojis[actualLevelIndex]);
    }
}
