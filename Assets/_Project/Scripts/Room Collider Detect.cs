using Meta.XR.MRUtilityKit;
using System.Collections;
using UnityEngine;

public class RoomColliderDetection : MonoBehaviour
{
    MRUKRoom room;
    Collider[] colliders;
    private void Start()
    {
        StartCoroutine(searchForRoom());
    }

    private void Update()
    {
        if(room != null)
        {
            GetAllColliders();
        }
    }

    private void AddColliders()
    {
        if(room != null)
        {
            foreach (Collider collider in colliders)
            {
                collider.gameObject.AddComponent<RoomCollision>();
            }
        }
    }

    public void GetAllColliders()
    {
        colliders = room.GetComponentsInChildren<Collider>();
    }

    IEnumerator searchForRoom()
    {
        yield return new WaitForSeconds(10f);
        room = FindFirstObjectByType<MRUKRoom>();
        yield return new WaitForSeconds(1f);
        AddColliders();
    }
}
