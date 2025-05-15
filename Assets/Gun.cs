using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;
    public AudioSource gunSound;
    public RectTransform hitMarkerUI; // เป้าแบบ UI

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunSound.Play();

            Vector3 screenPos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Bottle bottle = hit.collider.GetComponent<Bottle>();
                if (bottle != null)
                {
                    bottle.OnHit();

                    // แปลงตำแหน่ง world ที่โดน ไปเป็นตำแหน่งบนหน้าจอ
                    Vector3 uiPosition = cam.WorldToScreenPoint(hit.point);
                    hitMarkerUI.position = uiPosition;

                    StartCoroutine(ShowHitMarker());
                }
            }
        }
    }

    IEnumerator ShowHitMarker()
    {
        hitMarkerUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hitMarkerUI.gameObject.SetActive(false);
    }
}