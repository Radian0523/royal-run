using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool gameOver = false;

    public bool GameOver => gameOver;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        bool flowControl = DecreaseTime();
        if (!flowControl)
        {
            return;
        }
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    private bool DecreaseTime()
    {
        if (gameOver) return false;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0)
        {
            PlayerGameOver();
        }

        return true;
    }

    void PlayerGameOver()
    {
        timeLeft = 0;
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
