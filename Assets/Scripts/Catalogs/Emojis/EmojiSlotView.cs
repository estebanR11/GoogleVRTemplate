using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EmojiSlotView : MonoBehaviour , IInteractive
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _selector;

    private UnityEvent OnPicked;

    public void ConfigureSlot(Sprite sprite, UnityEvent onPicked)
    {
        _image.sprite = sprite;
        _selector.gameObject.SetActive(false);

        OnPicked = onPicked;
    }

    public bool hasBeenSelected(){ return true; }

    public void OnPointerEnter(){}
    public void OnPointerExit(){}
    public void OnAction()
    {
        OnPicked.Invoke();
    }

}
