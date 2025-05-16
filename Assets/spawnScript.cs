using System.Collections;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;   // �ش spawn ���¨ش
    public GameObject[] bottles;      // Prefab �Ǵ��ҡ����Ẻ
    public float spawnInterval = 1.5f; // �������������ҧ spawn

    void Start()
    {
        StartCoroutine(SpawnRandomBottles());
    }

    IEnumerator SpawnRandomBottles()
    {
        yield return new WaitForSeconds(2f); // �͡�͹�����

        while (true)
        {
            // ��������ѧ������� (timeLeft > 0)
            if (GameManager.Instance != null && GameManager.Instance.timeLeft > 0)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                int bottleIndex = Random.Range(0, bottles.Length);

                Instantiate(bottles[bottleIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            }
            else
            {
                // ������� �����ش spawn
                StopAllBottlesMoving(); // �����ش��¡�л�ͧ
                yield break;  // �͡�ҡ coroutine
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
