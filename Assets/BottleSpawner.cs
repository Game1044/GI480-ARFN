using UnityEngine;
using System.Collections.Generic;

public class BottleSpawner : MonoBehaviour
{
    public static BottleSpawner Instance;

    public List<GameObject> bottlePrefabs;  // �� prefab �ͧ�Ǵ����� Ẻ
    public float spawnInterval = 2f;  // ���������ҧ��� spawn �Ǵ
    private float spawnTimer;
    private bool isPlaying = true;    // ����÷����͡������ѧ��診

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // ��˹� Instance ����繵�ǹ��
        }
        else
        {
            Destroy(gameObject);  // ����� Instance ��������������µ�ǹ��
        }
    }

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        // ��������ѧ��診��͹���� spawn
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
        isPlaying = false;  // ��ش��� spawn ���������
    }

    void SpawnBottle()
    {
        if (bottlePrefabs.Count > 0 && Camera.main != null)
        {
            int randomIndex = Random.Range(0, bottlePrefabs.Count);
            GameObject bottleToSpawn = bottlePrefabs[randomIndex];

            // �������˹��˹�Ҩ� (Viewport space: x=0..1, y=0..1)
            float x = Random.Range(0.1f, 0.9f); // ������Դ�ͺ��
            float y = Random.Range(0.1f, 0.9f);
            float z = 5f; // ������ҧ�ҡ���ͧ (��Ѻ���������֡����ͧ���)

            Vector3 viewportPos = new Vector3(x, y, z);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);

            GameObject spawnedBottle = Instantiate(bottleToSpawn, worldPos, Quaternion.Euler(0,180,0));
            

            Destroy(spawnedBottle, 2f); // ź�͡��ѧ 2 ��

        }
    }

}
