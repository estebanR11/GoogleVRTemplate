using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelector : MonoBehaviour
{
    [SerializeField] Sprite icon;
    [SerializeField] Image iconImage;
    [SerializeField] int musicId;
    [SerializeField] TextMeshProUGUI musicText;
    [SerializeField] string musicName;
    [SerializeField] GameObject blocker;
    float count;

    private void Start()
    {
        musicText.text = musicName;
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
        blocker.SetActive(true);
        GameManager.Instance.SetMusicId(musicId);
    }


}
