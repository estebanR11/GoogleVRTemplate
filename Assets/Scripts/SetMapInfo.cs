using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetMapInfo : MonoBehaviour, IInteractive
{


    [SerializeField] LevelDataSO mapData;
    [SerializeField] Image image;
    [SerializeField] GameObject selector;
    [SerializeField] SetMapInfo[] allMaps;
    bool isPointed = false;
    [SerializeField] float count;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] ConfirmButton confirmButton;
    private void Start()
    {
        image = GetComponent<Image>();

        selector.SetActive(false);
        text.text = mapData.levelName;
    }

    public bool hasBeenSelected() { return true; }
    public void OnPointerEnter() { }
    public void OnPointerExit() { }


    public void OnAction()
    {
        selector.SetActive(true);
        GameManager.Instance.SelectLevelId(mapData.id);
        confirmButton.CanSelect = true;
        deactivateSelectors(this);
    }
    public void DeactivateSelector()
    {
        selector.SetActive(false);
    }

    private void deactivateSelectors(SetMapInfo info)
    {
        for (int i = 0; i < allMaps.Length; i++)
        {
            allMaps[i].DeactivateSelector();
        }
    }

}
