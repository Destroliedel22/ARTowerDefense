using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField]List<GameObject> crystals = new List<GameObject>();

    private GameObject playField;
    private Vector3 playFieldSize;

    private void Awake()
    {
        playField = gameObject.transform.parent.gameObject;
        playFieldSize = playField.GetComponent<Renderer>().bounds.size;
    }

    private void Start()
    {
        SpawnCrystals();
    }

    private void SpawnCrystals()
    {
        foreach (GameObject crystal in crystals)
        {
            Vector3 spawnPos = new Vector3(Random.Range(playFieldSize.x, playFieldSize.x - playFieldSize.x), 0, Random.Range(playFieldSize.z, playFieldSize.z - playFieldSize.z));
            GameObject clone = Instantiate(crystal, spawnPos, crystal.transform.rotation, playField.transform);
        }
    }
}
