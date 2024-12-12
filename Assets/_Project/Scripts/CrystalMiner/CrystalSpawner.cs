using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField]List<GameObject> crystals = new List<GameObject>();

    private GameObject playField;
    private Vector3 playFieldSize;
    private float spawnAmount;

    private void Awake()
    {
        playField = transform.parent.gameObject.GetNamedChild("Main Ground");
        playFieldSize = playField.GetComponent<Collider>().bounds.size;
    }

    private void Start()
    {
        SpawnCrystals();
    }

    private void SpawnCrystals()
    {
        while(spawnAmount < 10)
        {
            GameObject randomCrystal = crystals[Random.Range(0, crystals.Count)];
            GameObject clone = Instantiate(randomCrystal, transform.parent.parent.parent);
            Vector3 spawnPos = new Vector3(Random.Range(playFieldSize.x / 2 - playFieldSize.x / 20, -playFieldSize.x / 2 - -playFieldSize.x / 20), randomCrystal.transform.position.y + 1, Random.Range(playFieldSize.z / 2 - playFieldSize.z / 20, -playFieldSize.z / 2 - -playFieldSize.z / 20));
            clone.transform.localPosition = spawnPos;
            spawnAmount++;
        }
    }
}
