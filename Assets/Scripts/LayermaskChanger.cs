using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayermaskChanger : MonoBehaviour
{
    [SerializeField] GameObject[] gameobjectsToChange;
    [SerializeField] LayerMask layer;
    

    public void SetLayer()
    {
        for(int i = 0; i < gameobjectsToChange.Length; i++)
        {
            gameobjectsToChange[i].layer = layer;
        }
    }

}
