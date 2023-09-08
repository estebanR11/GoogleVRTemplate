using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private Image imageToFade; // La imagen cuyo color deseas desvanecer.
    [SerializeField] private float fadeDuration = 2.0f; // Duración en segundos del desvanecimiento.
    [SerializeField] Color startColor ; // Guarda el color inicial.
    [SerializeField] Color targetColor; // Copia del color inicial para modificar gradualmente.
    private void Start()
    {
        imageToFade = GetComponent<Image>();    
    }
    private void OnEnable()
    {
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {

        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration); // Normaliza el tiempo entre 0 y 1.

            // Interpola gradualmente el alfa hacia 0.
            targetColor.a = Mathf.Lerp(startColor.a, 0f, t);
            imageToFade.color = targetColor;

            yield return null;
        }

        // Asegúrate de que el alfa sea 0 al final.
        targetColor.a = 0f;
        imageToFade.color = targetColor;

        // Desactiva el objeto o realiza cualquier otra acción que desees después del desvanecimiento.
        gameObject.SetActive(false);
    }
}
