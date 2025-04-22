using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class FaceDetectorUI : MonoBehaviour
{
    public ARFaceManager faceManager;
    public GameObject startButton;

    private bool faceDetected = false;

    void Update()
    {
        // ถ้าเจอหน้าแล้ว
        if (!faceDetected && faceManager.trackables.count > 0)
        {
            Debug.Log("เจอใบหน้าแล้ว!");
            faceDetected = true;
            startButton.SetActive(true); // แสดงปุ่ม Start
        }

        // ถ้าหน้าหายไป อยากให้ปุ่มหายไปด้วยไหม?
        // ถ้าใช่ เติมด้านล่างนี้:
        if (faceDetected && faceManager.trackables.count == 0)
        {
            faceDetected = false;
            startButton.SetActive(false); // ซ่อนปุ่ม
        }
    }
}
