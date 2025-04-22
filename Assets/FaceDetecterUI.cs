using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class FaceDetectorUI : MonoBehaviour
{
    public ARFaceManager faceManager;
    public GameObject startButton;

    private bool faceDetected = false;

    void Update()
    {
        // �����˹������
        if (!faceDetected && faceManager.trackables.count > 0)
        {
            Debug.Log("���˹������!");
            faceDetected = true;
            startButton.SetActive(true); // �ʴ����� Start
        }

        // ���˹������ ��ҡ���������仴������?
        // ����� �����ҹ��ҧ���:
        if (faceDetected && faceManager.trackables.count == 0)
        {
            faceDetected = false;
            startButton.SetActive(false); // ��͹����
        }
    }
}
