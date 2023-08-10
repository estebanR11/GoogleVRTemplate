using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyRandom : MonoBehaviour
{
    public float circleRadius = 5f;
    public float verticalRange = 2f;
    public float rotationSpeed = 2f;

    private float verticalOffset;
    private float elapsedTime;

    void Start()
    {
        // Inicializa una posición vertical aleatoria para la mariposa
        verticalOffset = Random.Range(-verticalRange, verticalRange);
    }

    void Update()
    {
        // Incrementa el tiempo transcurrido
        elapsedTime += Time.deltaTime;

        // Calcula la posición local en el círculo
        float xPos = Mathf.Cos(elapsedTime * rotationSpeed) * circleRadius;
        float zPos = Mathf.Sin(elapsedTime * rotationSpeed) * circleRadius;

        // Combina la posición local del círculo con la posición vertical aleatoria
        Vector3 localPosition = new Vector3(xPos, verticalOffset, zPos);

        // Actualiza la posición local del objeto
        transform.localPosition = localPosition;

        // Calcula la rotación para que mire hacia el centro del círculo en la posición local
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.zero - localPosition, Vector3.up);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
