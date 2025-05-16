using UnityEngine;

public class Bottle : MonoBehaviour
{
    public int pointValue = 10;  // กำหนดแต้มของกระป๋องแต่ละอัน (ปรับค่าได้ใน Inspector)
    public bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0.2f);
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
