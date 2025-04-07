using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI CurrentScoreText;
    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GM.OnScoreChanged += UpdateScoreUI;
    }
    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GM.OnScoreChanged -= UpdateScoreUI;
    }
    private void Start()
    {
        HighScoreText.text = $"HighScore : {GM.NowPlayerData.HighScore.ToString()}";
        CurrentScoreText.text = "Score : 0";
    }

    private void UpdateScoreUI(int newScore)
    {
        CurrentScoreText.text = $"Score : {newScore.ToString()}";
    }
}
