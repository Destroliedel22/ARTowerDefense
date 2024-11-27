using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = FindAnyObjectByType<Camera>();
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.LookAt(camera.transform);
    }
}
