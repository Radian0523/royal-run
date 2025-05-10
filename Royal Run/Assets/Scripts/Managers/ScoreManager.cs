using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    private int score = 0;

    public void IncreaseScore(int amount)
    {
        if (gameManager.GameOver) return;
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString("D");
    }
}
