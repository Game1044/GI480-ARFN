using UnityEngine;

public class Bottle : MonoBehaviour
{
    public int pointValue = 10;
    public GameObject hitEffectSpritePrefab;

    public void OnHit()
    {
        GameObject effect = Instantiate(hitEffectSpritePrefab, transform.position, Quaternion.identity);

        // ลบภาพหลัง 0.5 วินาที
        Destroy(effect, 0.5f);
        GameManager.Instance.AddScore(pointValue);
        Destroy(gameObject);
    }
}
