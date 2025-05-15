using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARCanSpawner : MonoBehaviour
{
    public GameObject[] canPrefabs; // เปลี่ยนจาก 1 อัน เป็นหลายอัน
    public float spawnInterval = 1f;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        StartCoroutine(SpawnCansRepeatedly());
    }

    IEnumerator SpawnCansRepeatedly()
    {
        while (true)
        {
            TrySpawnCan();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void TrySpawnCan()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.Planes))
        {
            Pose hitPose = hits[Random.Range(0, hits.Count)].pose;

            Vector3 spawnOffset = new Vector3(
                Random.Range(-0.5f, 0.5f),
                0f,
                Random.Range(-0.5f, 0.5f)
            );

            Vector3 spawnPos = hitPose.position + spawnOffset;

            // สุ่มเลือกกระป๋อง
            int randomIndex = Random.Range(0, canPrefabs.Length);
            GameObject selectedCan = canPrefabs[randomIndex];

            Instantiate(selectedCan, spawnPos, Quaternion.identity);
        }
    }
}