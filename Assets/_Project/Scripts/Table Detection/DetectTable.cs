using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DetectTable : MonoBehaviour
{
    List<ARPlane> planes = new List<ARPlane>();
    ARPlaneManager planeManager;
    ARPlane highestPlane;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        foreach (var plane in planeManager.trackables)
        {
            planes.Add(plane);
        }
    }

    private void Update()
    {
        SubscribeToPlanesChanged();
    }

    public void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARPlane> changes)
    {
        foreach (var plane in changes.added)
        {
            if (plane.transform.position.y > highestPlane.transform.position.y || highestPlane == null)
            {
                highestPlane = plane;
            }
            else
            {
                plane.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    void SubscribeToPlanesChanged()
    {
        planeManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }
}
