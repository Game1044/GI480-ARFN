using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string sceneToLoad = "GameScene"; // เปลี่ยนชื่อ Scene ตามที่คุณต้องการ

    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
