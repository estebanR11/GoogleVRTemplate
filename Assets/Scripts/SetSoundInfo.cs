using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetSoundInfo : MonoBehaviour
{

    [SerializeField] MusicDataSO musicData;
    [SerializeField] Image image;
    [SerializeField] GameObject selector;
    [SerializeField] SetSoundInfo[] allSounds;
    bool isPointed = false;
    [SerializeField] float count;
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = musicData.musicSprite;
        selector.SetActive(false);
        text.text = musicData.musicName;
    }
    public void OnPointerEnter()
    {
      
        isPointed = true;
        StartCoroutine(Selector());
    }


    public void OnPointerExit()
    {
        isPointed = false;

        StopAllCoroutines();
        count = 0f;
    }
    IEnumerator Selector()
    {

        while (count < 1f && isPointed)
        {
            count += Time.deltaTime;
            yield return null;
        }
        selector.SetActive(true);
        GameManager.Instance.SelectMusicId(musicData.musicClip);
        deactivateSelectors(this);
    }

    public void DeactivateSelector()
    {
        selector.SetActive(false);
    }

    private void deactivateSelectors(SetSoundInfo info)
    {
        for (int i = 0; i < allSounds.Length; i++)
        {
            allSounds[i].DeactivateSelector();
        }
    }
}
