using UnityEditor.Animations;
using UnityEngine;

public class ImprovisedEventSystemFacade : MonoBehaviour 
{
    public Animator _instructorController;
    public FadeEyesView _fadeEyesView;

    public void InstructorStart()
    {
        _instructorController.SetBool("Start", true);
    }
    public void InstructorEnd()
    {
        _instructorController.SetBool("Start",false);
    }

    public void OpenEyes()
    {
        _fadeEyesView.Show();
    }

    public void CloseEyes()
    {
        _fadeEyesView.Hide();
    }

    public void InvokeEvent(GuideEvents currentEvent)
    {
        switch (currentEvent)
        {
            case GuideEvents.Nothing:
                Debug.Log("NothingEvent");
                break;
            case GuideEvents.InstructorStart:
                InstructorStart();
                break;
            case GuideEvents.InstructorEnd:
                InstructorEnd();
                break;
            case GuideEvents.CloseEyes:
                OpenEyes();
                break;
            case GuideEvents.OpenEyes:
                CloseEyes();
                break;
            default:
                break;
        }
    }
}
