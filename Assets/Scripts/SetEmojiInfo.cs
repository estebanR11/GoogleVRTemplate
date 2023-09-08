using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetEmojiInfo : MonoBehaviour
{
    [SerializeField] EmojiDataSO emojiInfo;
    [SerializeField] Image image;
    [SerializeField] GameObject selector;
    [SerializeField] SetEmojiInfo[] allEmojis;
    bool isPointed = false;
    [SerializeField] float count;
    [SerializeField] ConfirmButton confirm;
    [SerializeField] UnityEvent OnPicked;
    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = emojiInfo.emojiSprite;
        selector.SetActive(false);
        confirm.enabled = false;
    }
    public void OnPointerEnter()
    {

        isPointed=true;
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
        GameManager.Instance.SetNewEmojiData(emojiInfo);
        OnPicked.Invoke();
        deactivateSelectors(this);
    }

    public void DeactivateSelector()
    {
        selector.SetActive(false);
    }

    private void deactivateSelectors(SetEmojiInfo info)
    {
        for(int i = 0; i < allEmojis.Length;    i++)
        {
            allEmojis[i].DeactivateSelector();
        }
    }
}
