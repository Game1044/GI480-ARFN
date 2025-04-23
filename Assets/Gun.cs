using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;
    public AudioSource gunSound; // เพิ่มตัวแปรเสียง

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // เล่นเสียงปืน
            gunSound.Play();

            Vector3 screenPos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(screenPos);

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

