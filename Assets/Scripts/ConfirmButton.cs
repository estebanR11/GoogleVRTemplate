using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ConfirmButton : MonoBehaviour, IPointer
{
    public UnityEvent OnConfirm;

    float count;

    public bool CanSelect = false;

    
    public bool hasBeenSelected()
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter()
    {
        if(CanSelect)
         StartCoroutine(Selector());
    }


    public void OnPointerExit()
    {
       

        StopAllCoroutines();
        count = 0f;
    }
    IEnumerator Selector()
    {

        while (count < 1.5f )
        {
            count += Time.deltaTime;
            yield return null;
        }

        OnConfirm.Invoke();


    }

    private void OnDisable()
    {
        count = 0;
        StopAllCoroutines();
    }
}
