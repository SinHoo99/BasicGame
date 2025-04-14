using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI CurrentScoreText;
    [SerializeField] private TextMeshProUGUI NowScoreText;
    private void OnEnable()
    {
        EventBus.Subscribe<PlayerScoreUpEvent>(UpdateScoreUI);
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerScoreUpEvent>(UpdateScoreUI);
    }
    private void Start()
    {
        HighScoreText.text = $"HighScore : {GM.NowPlayerData.HighScore.ToString()}";
        CurrentScoreText.text = "Score : 0";
    }

    private void UpdateScoreUI(PlayerScoreUpEvent e)
    {
        CurrentScoreText.text = $"{e.CurrentScore}";
        NowScoreText.text = $"Score : {e.CurrentScore}";
    }
}
