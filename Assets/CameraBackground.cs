using UnityEngine;
using UnityEngine.UI;

public class CameraBackground : MonoBehaviour
{
    public RawImage rawImage;
    private WebCamTexture webCamTexture;
    

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        string backCamName = null;                                                             

        // หา "กล้องหลัง"
        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCamName = devices[i].name;
                break;
            }
        }

        // ถ้ามีกล้องหลัง → ใช้
        if (backCamName != null)
        {
            webCamTexture = new WebCamTexture(backCamName, Screen.width, Screen.height);
            rawImage.texture = webCamTexture;
            rawImage.material.mainTexture = webCamTexture;

            webCamTexture.Play();
        }
        else
        {
            Debug.LogWarning("ไม่พบกล้องหลัง");
        }
        
    }
}

