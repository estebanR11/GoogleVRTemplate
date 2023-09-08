using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    [SerializeField] private Image imageToFade; // La imagen cuyo color deseas hacer aparecer gradualmente.
    [SerializeField] private float fadeDuration = 2.0f; // Duración en segundos de la aparición gradual.
    [SerializeField] Color startColor;
    [SerializeField] Color targetColor;
    float alphaValue;
    private void OnEnable()
    {
        StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
      
        float elapsedTime = 0.0f;



        imageToFade.color = targetColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration); // Normaliza el tiempo entre 0 y 1.

            // Interpola gradualmente el alfa hacia 1.
       
            imageToFade.color = targetColor;

            yield return null;
        }

        // Asegúrate de que el alfa sea 1 al final.
        targetColor.a = startColor.a;
        imageToFade.color = targetColor;

        gameObject.SetActive(false);
        // Puedes realizar cualquier acción adicional después de la aparición gradual aquí.
    }
}
