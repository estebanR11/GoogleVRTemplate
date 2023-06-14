using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeelingSelector : MonoBehaviour,IPointer
{
    [SerializeField] Sprite icon;
    [SerializeField] int emotionValue;
    [SerializeField] TextMeshProUGUI textEmotion;
    [SerializeField] string emotion;
    float count;
    private void Start()
    {
        textEmotion.text = emotion;
        GetComponent<Image>().sprite = icon;
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

        GameManager.Instance.SetEmotionId(emotionValue);
    }

}
