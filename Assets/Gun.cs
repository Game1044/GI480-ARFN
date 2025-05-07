using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;
    public AudioSource gunSound;
    public RectTransform hitMarkerUI;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunSound.Play();

            // แสดงเป้าในตำแหน่งที่ผู้เล่นคลิก


            // ตรวจสอบว่ากระสุนโดนอะไรหรือไม่
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Bottle bottle = hit.collider.GetComponent<Bottle>();
                if (bottle != null)
                {
                    bottle.OnHit();
                }
            }
        }
    }


}