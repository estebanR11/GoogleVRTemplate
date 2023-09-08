using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EmojiSlotView : MonoBehaviour 
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _selector;

    private bool _isPointed = false;
    private float _count;
    private UnityEvent OnPicked;


    public void ConfigureSlot(Sprite sprite, UnityEvent onPicked)
    {
        _image.sprite = sprite;
        _selector.gameObject.SetActive(false);

        OnPicked = onPicked;
    }

    public void OnPointerEnter()
    {
        _isPointed = true;
        StartCoroutine(Selector());
    }

    public void OnPointerExit()
    {
        _isPointed = false;

        StopAllCoroutines();
        _count = 0f;
    }

    IEnumerator Selector()
    {
        while (_count < 1f && _isPointed)
        {
            _count += Time.deltaTime;
            yield return null;
        }
        //GameManager.Instance.SetNewEmojiData(emojiInfo);
        OnPicked.Invoke();
    }

}
