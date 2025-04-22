using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreText; // ข้อความแสดงคะแนน
    public TMP_Text timerText; // ข้อความแสดงเวลา
    public GameObject gameOverPanel;  // Panel ที่แสดงเมื่อเกมจบ
    public TMP_Text finalScoreText;   // ข้อความแสดงคะแนนสุดท้าย
    public Button restartButton;      // ปุ่ม Restart
    public Button quitButton;         // ปุ่ม Quit

    public int score = 0;
    public float timeLeft = 30f;
    private bool isPlaying = true;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // ซ่อน GameOverPanel ตอนเริ่มเกม
        gameOverPanel.SetActive(false);

        // กำหนดปุ่มให้ทำงาน
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
            ShowGameOver();  // เรียกใช้งานฟังก์ชัน ShowGameOver
            HideScoreAndTime(); // ซ่อน UI score และ time
        }

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        if (!isPlaying) return;  // หยุดการเพิ่มคะแนนเมื่อเกมจบ
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
        // แสดงผล Game Over Panel
        if (finalScoreText != null) finalScoreText.text = "Final Score: " + score;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);  // แสดง Panel

        // หยุดการ spawn ขวดทั้งหมด
        if (BottleSpawner.Instance != null)
        {
            BottleSpawner.Instance.StopSpawning();
        }
    }

    void HideScoreAndTime()
    {
        // ซ่อน Score และ Timer UI
        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (timerText != null) timerText.gameObject.SetActive(false);
    }

    void RestartGame()
    {
        // รีโหลดฉากเพื่อเริ่มเกมใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        // ออกจากเกม
        Application.Quit();
    }
}
