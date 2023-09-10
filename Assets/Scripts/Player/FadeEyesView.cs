using UnityEngine;

public class FadeEyesView : MonoBehaviour 
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup.alpha = 1;
        Hide();
    }

    public void Show()
    {
        _canvasGroup.LeanAlpha(1, 1.5f);

    }

    public void Hide()
    {
        _canvasGroup.LeanAlpha(0, 1.5f);
    }
}
