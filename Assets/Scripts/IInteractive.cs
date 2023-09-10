using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractive 
{
    public void OnPointerEnter();
    public void OnPointerExit();
    public void OnAction();
    public bool hasBeenSelected();
}
