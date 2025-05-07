using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI CurrentScoreText;
    [SerializeField] private TextMeshProUGUI NowScoreText;
    /* [SerializeField] private TextMeshProUGUI NowCoinText;*/

    [SerializeField] private GameObject scoreEffectPrefab;
    [SerializeField] private RectTransform canvasTransform;

    private void OnEnable()
    {
        EventBus.Subscribe<PlayerScoreUpEvent>(UpdateScoreUI);
       // EventBus.Subscribe<PlayerCoinUpEvent>(UpdateCoinUI);
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerScoreUpEvent>(UpdateScoreUI);
       // EventBus.Unsubscribe<PlayerCoinUpEvent>(UpdateCoinUI);
    }
    private void Start()
    {
        HighScoreText.text = $"High : {GM.NowPlayerData.HighScore.ToString()}";
        //NowCoinText.text = $"{GM.NowPlayerData.Coin.ToString()}";
        CurrentScoreText.text = "0";
    }

    private void UpdateScoreUI(PlayerScoreUpEvent e)
    {
        CurrentScoreText.text = $"{e.CurrentScore}";
        NowScoreText.text = $"Score : {e.CurrentScore}";

        Vector2 screenPos = Camera.main.WorldToScreenPoint(e.WorldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasTransform, screenPos, Camera.main, out Vector2 localPos
        );

        GameObject fx = Instantiate(scoreEffectPrefab, canvasTransform);
        fx.GetComponent<RectTransform>().anchoredPosition = localPos;
    }
/*    private void UpdateCoinUI(PlayerCoinUpEvent e)
    {
        NowCoinText.text = $"{e.CurrentCoin}";   
    }*/
}
