using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour, IPointer
{
    [SerializeField] Sprite icon;
    [SerializeField] Image iconImage;
    [SerializeField] int levelValue;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] string levelName;
    [SerializeField] GameObject blocker;
    float count;

    private void Start()
    {
        levelText.text = levelName;
        iconImage.sprite = icon;
    }
    public void OnPointerEnter()
    {
        StartCoroutine(Selector());
    }

    public void OnPointerExit()
    {
        StopCoroutine(Selector());
        count = 0f;
    }

    IEnumerator Selector()
    {
        while (count < 3)
        {
            count += Time.deltaTime;
            yield return null;
        }
        GameManager.Instance.SetLevelId(levelValue);
        blocker.SetActive(true);
    }



}
