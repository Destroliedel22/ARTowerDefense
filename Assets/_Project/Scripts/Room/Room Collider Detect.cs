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

    //adds script to all colliders in the room
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

    //gets all colliders of the room
    public void GetAllColliders()
    {
        colliders = room.GetComponentsInChildren<Collider>();
    }

    //searches for the room
    IEnumerator searchForRoom()
    {
        yield return new WaitForSeconds(10f);
        room = FindFirstObjectByType<MRUKRoom>();
        yield return new WaitForSeconds(1f);
        AddColliders();
    }
}
