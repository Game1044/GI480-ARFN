using UnityEngine;
using System.Collections.Generic;

public class BottleSpawner : MonoBehaviour
{
    public static BottleSpawner Instance;

    public List<GameObject> bottlePrefabs;  // เก็บ prefab ของขวดหลายๆ แบบ
    public float spawnInterval = 2f;  // เวลาระหว่างการ spawn ขวด
    private float spawnTimer;
    private bool isPlaying = true;    // ตัวแปรที่ใช้บอกว่าเกมยังไม่จบ

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // กำหนด Instance ให้เป็นตัวนี้
        }
        else
        {
            Destroy(gameObject);  // ถ้ามี Instance อยู่แล้วให้ทำลายตัวนี้
        }
    }

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        // เช็คว่าเกมยังไม่จบก่อนที่จะ spawn
        if (!isPlaying) return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnBottle();
            spawnTimer = spawnInterval;
        }
    }

    public void StopSpawning()
    {
        isPlaying = false;  // หยุดการ spawn เมื่อเกมจบ
    }

    void SpawnBottle()
    {
        if (bottlePrefabs.Count > 0 && Camera.main != null)
        {
            int randomIndex = Random.Range(0, bottlePrefabs.Count);
            GameObject bottleToSpawn = bottlePrefabs[randomIndex];

            // สุ่มตำแหน่งในหน้าจอ (Viewport space: x=0..1, y=0..1)
            float x = Random.Range(0.1f, 0.9f); // ไม่ให้ติดขอบจอ
            float y = Random.Range(0.1f, 0.9f);
            float z = 5f; // ระยะห่างจากกล้อง (ปรับได้ตามความลึกที่ต้องการ)

            Vector3 viewportPos = new Vector3(x, y, z);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);

            GameObject spawnedBottle = Instantiate(bottleToSpawn, worldPos, Quaternion.identity);
            Destroy(spawnedBottle, 2f); // ลบออกหลัง 2 วิ

        }
    }

}
