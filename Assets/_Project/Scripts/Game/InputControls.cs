using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
    private ARControls arControls;
    private InputAction controls;

    private Camera mainCamera;

    [SerializeField] private float mouseDragSpeed = 15f;
    [SerializeField] private float dragSpeed = 0.1f;
    private Vector3 velocity = Vector3.zero;

    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    private void Awake()
    {
        arControls = new ARControls();
        mainCamera = Camera.main;
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

        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        // If the raycast hits something, store it in the hit
        if (Physics.Raycast(ray, out hit))
        {
            // If this object has a collider and is an interactable object, then move this object with the input
            if (hit.collider != null && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable")) || hit.collider.gameObject.GetComponent<IHold>() != null)
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }

    // Make own update
    private IEnumerator DragUpdate(GameObject holdingObject)
    {
        // Calcute the distance between the object and player
        float objectDistance = Vector3.Distance(holdingObject.transform.position, mainCamera.transform.position);
        holdingObject.TryGetComponent<Rigidbody>(out Rigidbody rb);
        holdingObject.TryGetComponent<IHold>(out IHold iHoldComponent);
        // If the component is not null, then execute the OnStartHold function
        iHoldComponent?.OnStartHold();

        // Check if the input is given
        while (arControls.Controls.MoveObjects.ReadValue<float>() != 0)
        {
            // Update the location of the mouse
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            // Only move the object if it has an RigidBody
            if (rb != null)
            {
                // Constantly move the object to the raycast point times the mousedrag speed
                Vector3 direction = ray.GetPoint(objectDistance) - holdingObject.transform.position;
                rb.linearVelocity = direction * mouseDragSpeed;
                yield return waitForFixedUpdate;
            }
            else
            {
                // Move the object
                holdingObject.transform.position = Vector3.SmoothDamp(holdingObject.transform.position, ray.GetPoint(objectDistance), ref velocity, dragSpeed);
                // Wait for next FixedUpdate frame
                yield return null;
            }
        }

        // If the component is not null, then execute the OnStopHold function
        iHoldComponent?.OnStopHold();
    }
}