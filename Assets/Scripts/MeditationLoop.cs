using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MeditationLoop : MonoBehaviour
{
    [SerializeField]List<MeditacionSO> meditacionSOs;

    [SerializeField]int actualStep;

    [SerializeField] GameObject textGuideObject;
    [SerializeField] TextMeshProUGUI guideText;
    [SerializeField] AudioSource asource;
    [SerializeField] List<PointsPosition> pointsPosition;
    private void Start()
    {
        actualStep = -1;
        textGuideObject.SetActive(true);
        for (int i = 0; i < pointsPosition.Count; i++)
        {
            pointsPosition[i].gameObject.SetActive(false);
        }
        SetNextPoint();
    }



    public void SetNextPoint()
    {
        textGuideObject.SetActive(true);
        actualStep++;
        if(actualStep> meditacionSOs.Count-1)
        {
            for (int i = 0; i < pointsPosition.Count; i++)
            {
                pointsPosition[i].gameObject.SetActive(false);
            }

            textGuideObject.SetActive(false);
            return;
        }
        guidePosition actualPos = meditacionSOs[actualStep].dataMeditacion.guidePosition;

        if(actualPos!=guidePosition.Vacio)
        {
            for (int i = 0; i < pointsPosition.Count; i++)
            {
                if (pointsPosition[i].GetGuidePosition() == actualPos)
                {
        
                    pointsPosition[i].gameObject.SetActive(true);
                }
                else
                {
                    pointsPosition[i].gameObject.SetActive(false);
                }
            }
         
        }
        else
        {
            for (int i = 0; i < pointsPosition.Count; i++)
            {
                pointsPosition[i].gameObject.SetActive(false);
            }
            StartCoroutine(timerWhenEmpty());
        }
        
        if(meditacionSOs[actualStep].dataMeditacion.audio !=null)
        {
            asource.clip = meditacionSOs[actualStep].dataMeditacion.audio;asource.Play();
        }

        guideText.text = meditacionSOs[actualStep].dataMeditacion.mensaje;
    }

    IEnumerator timerWhenEmpty()
    {
        yield return new WaitForSeconds(8.0f);
        SetNextPoint();
    }
}
