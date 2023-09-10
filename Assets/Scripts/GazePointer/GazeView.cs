using UnityEngine;
using UnityEngine.UI;

public class GazeView : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] Image _circle;

    private void Start()
    {
        _canvasGroup.alpha = 0;
    }

    public void Show()
    {
        _canvasGroup.LeanAlpha(1, 0.2f);
    }

    public void Hide()
    {
        _canvasGroup.LeanAlpha(0, 0.2f);
    }

    public void UpdateLoad(float load)
    {
        _circle.fillAmount = load;
    }

}
