using UnityEngine;
using TMPro;

public class GuideTextView : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] TextMeshProUGUI guideText;

    private void Start()
    {
      //  _canvasGroup.alpha = 0;
    }

    public void Show()
    {
    //    _canvasGroup.LeanAlpha(1, 0.5f);
    }

    public void Hide()
    {
    //    _canvasGroup.LeanAlpha(0, 0.5f);
    }

    public void UpdateText(string text)
    {
        //guideText.text = text;
    }
}
