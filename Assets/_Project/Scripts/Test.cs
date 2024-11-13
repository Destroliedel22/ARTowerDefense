using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Test : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;

    void OnEnable()
    {
        // Subscribe to the planesChanged event
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged += OnPlanesChanged;
        }
    }

    void OnDisable()
    {
        // Unsubscribe from the planesChanged event
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged -= OnPlanesChanged;
        }
    }

    // This method will be called whenever planes are added, updated, or removed
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // Process added planes
        foreach (ARPlane plane in args.added)
        {
            Debug.Log("New plane detected at: " + plane.transform.position);
        }

        // Process updated planes
        foreach (ARPlane plane in args.updated)
        {
            Debug.Log("Plane updated at: " + plane.transform.position);
        }

        // Process removed planes
        foreach (ARPlane plane in args.removed)
        {
            Debug.Log("Plane removed with ID: " + plane.trackableId);
        }
    }
}
