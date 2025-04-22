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
            Debug.Log("���˹������!");
            // ����觷���ͧ����������˹�� �� �Դ���� Start
        }
        else
        {
            Debug.Log("�ѧ��辺˹��");
        }
    }
}
