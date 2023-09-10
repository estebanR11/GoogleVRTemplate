using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetSoundInfo : MonoBehaviour, IInteractive
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
        if (image == null)
            image = GetComponent<Image>();

        image.sprite = musicData.musicSprite;
        selector.SetActive(false);
        text.text = musicData.musicName;
    }
    public bool hasBeenSelected() { return true; }

    public void OnPointerEnter() { }
    public void OnPointerExit() { }
    public void OnAction()
    {
        selector.SetActive(true);
        GameManager.Instance.SelectMusicId(musicData.musicClip);
        deactivateSelectors(this);
    }

    private void deactivateSelectors(SetSoundInfo info)
    {
        for (int i = 0; i < allSounds.Length; i++)
        {
            allSounds[i].DeactivateSelector();
        }
    }
    public void DeactivateSelector()
    {
        selector.SetActive(false);
    }

}
