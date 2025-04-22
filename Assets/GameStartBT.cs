using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string sceneToLoad = "GameScene"; // ����¹���� Scene ������س��ͧ���

    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
