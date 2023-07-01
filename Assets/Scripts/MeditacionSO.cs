using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "MeditationData", menuName = "Meditation generator")]

public class MeditacionSO : ScriptableObject
{
    public MeditacionData dataMeditacion;


}

[System.Serializable]
public class MeditacionData
{
    public string mensaje;
    public AudioClip audio;
    public guidePosition guidePosition;
}

public enum guidePosition
{
    Arriba,
    Abajo,
    Izquierda,
    Derecha,
    DiagonalDerechaArriba,
    DiagonalDerechaAbajo,
    DiagonalIzquierdaArriba,
    DiagonalIzquierdaAbajo,
    DiagonalAtrasDerechaArriba,
    DiagonalAtrasDerechaAbajo,
    DiagonalAtrasIzquierdaArriba,
    DiagonalAtrasIzquierdaAbajo,
    Atras,
    Alfrente,
    Vacio
}