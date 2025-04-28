using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject gameOverPanel;

    protected override void Awake()
    {
        if (IsDuplicates()) return;

        base.Awake();
    }

    private void OnEnable()
    {
        EventBus.Subscribe<GameOverUIEvent>(OnGameOver);

    }
    private void OnDisable()
    {
        EventBus.Unsubscribe<GameOverUIEvent>(OnGameOver);
    }
    private void OnGameOver(GameOverUIEvent e)
    {
        GameManager.Instance.SetGameState(GameState.GameOver);
        Show(gameOverPanel);
    }
    public void Show(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void Hide(GameObject panel)
    {
        panel.SetActive(false);
    }
}
