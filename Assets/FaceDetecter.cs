using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceDetector : MonoBehaviour
{
    private ARFaceManager faceManager;

    void Awake()
    {
        faceManager = GetComponent<ARFaceManager>();
    }

    void Update()
    {
        if (faceManager.trackables.count > 0)
        {
            Debug.Log("พบใบหน้าแล้ว!");
            // ทำสิ่งที่ต้องการเมื่อเจอหน้า เช่น เปิดปุ่ม Start
        }
        else
        {
            Debug.Log("ยังไม่พบหน้า");
        }
    }
}
