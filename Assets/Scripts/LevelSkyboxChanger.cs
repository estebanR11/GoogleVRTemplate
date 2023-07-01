using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSkyboxChanger : MonoBehaviour
{
    [SerializeField] Material skyboxMaterial;

    private void OnEnable()
    {
        RenderSettings.skybox = skyboxMaterial;

        DynamicGI.UpdateEnvironment();
    }
}
