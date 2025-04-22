using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreText; // ��ͤ����ʴ���ṹ
    public TMP_Text timerText; // ��ͤ����ʴ�����
    public GameObject gameOverPanel;  // Panel ����ʴ����������
    public TMP_Text finalScoreText;   // ��ͤ����ʴ���ṹ�ش����
    public Button restartButton;      // ���� Restart
    public Button quitButton;         // ���� Quit

    public int score = 0;
    public float timeLeft = 30f;
    private bool isPlaying = true;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // ��͹ GameOverPanel �͹�������
        gameOverPanel.SetActive(false);

        // ��˹��������ӧҹ
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if (!isPlaying) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            isPlaying = false;
            ShowGameOver();  // ���¡��ҹ�ѧ��ѹ ShowGameOver
            HideScoreAndTime(); // ��͹ UI score ��� time
        }

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        if (!isPlaying) return;  // ��ش���������ṹ���������
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (timerText != null) timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    void ShowGameOver()
    {
        // �ʴ��� Game Over Panel
        if (finalScoreText != null) finalScoreText.text = "Final Score: " + score;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);  // �ʴ� Panel

        // ��ش��� spawn �Ǵ������
        if (BottleSpawner.Instance != null)
        {
            BottleSpawner.Instance.StopSpawning();
        }
    }

    void HideScoreAndTime()
    {
        // ��͹ Score ��� Timer UI
        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (timerText != null) timerText.gameObject.SetActive(false);
    }

    void RestartGame()
    {
        // ����Ŵ�ҡ���������������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        // �͡�ҡ��
        Application.Quit();
    }
}
