using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GazePointer : MonoBehaviour
{
    private enum GazeState
    {
        WaitPointer,
        Action,
        Enter,
        Exit
    };
    private GazeState _state;
    private const float _RETICLE_MAX_DISTANCE = 30.0f;
    private IInteractive _Interactive = null;
    public LayerMask ReticleInteractionLayerMask = 1 << _RETICLE_INTERACTION_DEFAULT_LAYER;
    private const int _RETICLE_INTERACTION_DEFAULT_LAYER = 8;

    [SerializeField] private GazeView _gazeView;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _actionTime;
    [SerializeField] private float minRotationX = -45.0f;
    [SerializeField] private float maxRotationX = 45.0f;
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _RETICLE_MAX_DISTANCE))
        {
            if (hit.transform.TryGetComponent<IInteractive>(out var interactableObject))
            {
                if (_Interactive != interactableObject)
                {
                    _Interactive = interactableObject;
                    _Interactive.OnPointerEnter();
                    _gazeView.Show();
                    _currentTime -= _currentTime;
                    _state = GazeState.Enter;
                }

                if (_state == GazeState.Enter)
                {
                    _currentTime += Time.deltaTime;
                    _gazeView.UpdateLoad(_currentTime / _actionTime);

                    if (_currentTime > _actionTime)
                    {
                        _Interactive.OnAction();
                        _state = GazeState.Action;
                    }
                }
            }
       
        }
        else
        {
            if (_state == GazeState.Enter || _state == GazeState.Action)
            {
                _Interactive.OnPointerExit();
                _gazeView.Hide();
                _Interactive = null;
                _state = GazeState.WaitPointer;
            }
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _Interactive.OnPointerEnter();
        }
        float currentRotationX = transform.rotation.eulerAngles.x;

        // Limita la rotación en el eje X
        currentRotationX = Mathf.Clamp(currentRotationX, minRotationX, maxRotationX);

        // Aplica la rotación limitada
        transform.rotation = Quaternion.Euler(currentRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    }
}
