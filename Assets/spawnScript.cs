using System.Collections;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;   // จุด spawn หลายจุด
    public GameObject[] bottles;      // Prefab ขวดหลากหลายแบบ
    public float spawnInterval = 1.5f; // ระยะเวลาระหว่าง spawn

    void Start()
    {
        StartCoroutine(SpawnRandomBottles());
    }

    IEnumerator SpawnRandomBottles()
    {
        yield return new WaitForSeconds(2f); // รอก่อนเริ่ม

        while (true)
        {
            // เช็คว่าเกมยังเล่นอยู่ (timeLeft > 0)
            if (GameManager.Instance != null && GameManager.Instance.timeLeft > 0)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                int bottleIndex = Random.Range(0, bottles.Length);

                Instantiate(bottles[bottleIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            }
            else
            {
                // ถ้าเกมจบ ให้หยุด spawn
                StopAllBottlesMoving(); // สั่งหยุดลอยกระป๋อง
                yield break;  // ออกจาก coroutine
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StopAllBottlesMoving()
    {
        Bottle[] bottlesInScene = FindObjectsOfType<Bottle>();

        foreach (Bottle b in bottlesInScene)
        {
            b.StopMoving();
        }
    }
}
