using UnityEngine;

public class Bottle : MonoBehaviour
{
    public int pointValue = 10;

    public void OnHit()
    {
        GameManager.Instance.AddScore(pointValue);
        Destroy(gameObject);
    }
}
