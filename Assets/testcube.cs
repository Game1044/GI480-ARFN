using UnityEngine;

public class TestFloat : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
    }
}
