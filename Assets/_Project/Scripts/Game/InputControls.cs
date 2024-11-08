using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
    private ARControls arControls;
    private InputAction controls;

    private void Awake()
    {
        arControls = new ARControls();
    }

    private void OnEnable()
    {
        controls = arControls.Controls.MoveObjects;
        arControls.Controls.MoveObjects.started += OnSelect;
        arControls.Controls.MoveObjects.canceled += OnSelect;
        arControls.Controls.Enable();
    }

    private void OnDisable()
    {
        controls = arControls.Controls.MoveObjects;
        arControls.Controls.MoveObjects.started -= OnSelect;
        arControls.Controls.MoveObjects.canceled -= OnSelect;
        arControls.Controls.Disable();
    }

    private void OnSelect(InputAction.CallbackContext value)
    {
        // if pressed, then stay on mouse position, until pressed again
    }
}