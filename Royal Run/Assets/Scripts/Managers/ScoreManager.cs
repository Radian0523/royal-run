using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString("D");
    }
}
