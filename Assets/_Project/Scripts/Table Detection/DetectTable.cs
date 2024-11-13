using Meta.XR.MRUtilityKit;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;


public class DetectTable : MonoBehaviour
{
    GameObject tablePrefab;
    GameObject room;
    GameObject table;

    BoxCollider tableCollider;

    public void SetupTable()
    {
        room = FindAnyObjectByType<MRUKRoom>().gameObject;
        table = room.transform.Find("TABLE").gameObject;
    }

    public void FindTable()
    {
        tableCollider = table.transform.Find("TABLE_EffectMesh").GetComponent<BoxCollider>();
        tablePrefab = gameObject.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        StartCoroutine(WaitToFindTable());
    }

    IEnumerator WaitToFindTable()
    {
        yield return new WaitForSeconds(10f);
        FindTable();
        tablePrefab.transform.localScale = new Vector3(tableCollider.size.x, tablePrefab.transform.localScale.y, tableCollider.size.z);
    }
}
