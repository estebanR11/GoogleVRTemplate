using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFiller : MonoBehaviour
{
    [SerializeField] Image circleImg;
    public float fillTime = 1.25f; // Tiempo en segundos para llenar el círculo al máximo
    private Coroutine fillCoroutine;
    [SerializeField] GameObject bg;

    public void OnPointerEnter()
    {
        circleImg.enabled = true;
        // Cancelar cualquier llenado en curso
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
        }
        bg.SetActive(true);
        // Iniciar el llenado gradual del círculo
        fillCoroutine = StartCoroutine(FillCircleOverTime(fillTime));
    }

    public void OnPointerExit()
    {
        // Cancelar cualquier llenado en curso
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
        }

        // Establecer el fillAmount a cero inmediatamente
        SetFillAmount(0f);
        bg.SetActive(false);
        circleImg.enabled= false;
    }

    private IEnumerator FillCircleOverTime(float time)
    {
        float elapsedTime = 0f;
        float startFillAmount = circleImg.fillAmount;
        float targetFillAmount = 1f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float fillPercentage = Mathf.Clamp01(elapsedTime / time);
            float currentFillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, fillPercentage);
            SetFillAmount(currentFillAmount);
            yield return null;
        }

        // Asegurarse de que el fillAmount sea exactamente 1 al finalizar
        SetFillAmount(targetFillAmount);
    }

    private void SetFillAmount(float fillAmount)
    {
        circleImg.fillAmount = fillAmount;
    }

}
