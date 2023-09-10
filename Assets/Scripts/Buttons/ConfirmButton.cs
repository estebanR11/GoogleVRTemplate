using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ConfirmButton : MonoBehaviour, IInteractive
{
    public UnityEvent OnConfirm;
    public bool CanSelect = false;

    public bool hasBeenSelected(){return true;}
    public void OnPointerEnter(){}
    public void OnPointerExit(){}

    public void OnAction()
    {
        if (CanSelect)
        {
        OnConfirm.Invoke();
        }
    }
}
