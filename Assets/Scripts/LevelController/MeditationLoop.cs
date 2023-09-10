using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeditationLoop : MonoBehaviour
{
    [SerializeField] private List<GuidesDataConfig> _guideTextData;
    private bool _start;

    [SerializeField] private GuideTextView _guideTextView;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ImprovisedEventSystemFacade _eventsSystem;

    private float _currentTime;

    private int _currentAudio;
    private int _currentStep;

    private GuideTextData _currentData;

    private void Start()
    {
        StartCoroutine(ConfigureStart());
    }

    private void Update()
    {
        if (!_start)
            return;

        _currentTime += Time.deltaTime;

        if (_currentTime > _currentData.TimeExecute)
        {
            TryPlayNextAudio();
        }

    }

    private IEnumerator ConfigureStart()
    {
        yield return new WaitForSeconds(3);

        _start = true;
        _currentStep = 0;
        _currentAudio = 0;
        _currentTime = 0;
        PlayNewAudio();
        NextData();
        _guideTextView.Show();
    }

    private void NextData()
    {
        _currentData = _guideTextData[_currentAudio].GetDataByIndex(_currentStep);
        _guideTextView.UpdateText(_currentData.Guide);
        _eventsSystem.InvokeEvent(_currentData.Event);
    }

    private void TryPlayNextAudio()
    {
        var dataSize = _guideTextData[_currentAudio].GetCountData();

        if (_currentStep < dataSize - 1)
        {
            _currentStep++;
            NextData();
            return;
        }


        if (IsAuioPlaying())
        {
            return;
        }

        _currentAudio++;

        if (_currentAudio >= _guideTextData.Count)
        {
            _start = false;
            _guideTextView.Hide();
            return;
        }

        _currentStep -= _currentStep;
        _currentTime -= _currentTime;

        NextData();
        PlayNewAudio();
    }

    private void PlayNewAudio()
    {
        _audioSource.clip = _guideTextData[_currentAudio].Clip;
        _audioSource.Play();
    }

    private bool IsAuioPlaying()
    {
       return _audioSource.isPlaying;
    }






    //[SerializeField] List<PointsPosition> pointsPosition;

    /*

    private void Start()
    {
        _currentStep = -1;
        textGuideObject.SetActive(true);
        for (int i = 0; i < pointsPosition.Count; i++)
        {
            pointsPosition[i].gameObject.SetActive(false);
        }
        //SetNextPoint();
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
    */

}
