using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera arCamera;
    public GameObject smokeEffect;
    public GameManager gameManager;

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            // ตรวจสอบว่า hit กับ GameObject ที่มี Tag "Bottle" หรือไม่
            if (hit.transform.CompareTag("Bottle"))
            {
                // ดึงสคริปต์ Bottle จาก object นั้น (ถ้ามี)
                Bottle bottle = hit.transform.GetComponent<Bottle>();

                // ทำลายขวด
                Destroy(hit.transform.gameObject);

                // สร้างควันตรงตำแหน่งโดนยิง
                Instantiate(smokeEffect, hit.point, Quaternion.LookRotation(hit.normal));

                // เพิ่มแต้ม ถ้ามีสคริปต์ Bottle อยู่
                if (bottle != null && gameManager != null)
                {
                    gameManager.AddScore(bottle.pointValue);
                }
            }
        }
    }
}
