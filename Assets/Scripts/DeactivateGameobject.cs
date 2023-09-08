using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameobject : MonoBehaviour
{
  
    public void EndAnimation()
    {
        gameObject.SetActive(false);    
    }
}
