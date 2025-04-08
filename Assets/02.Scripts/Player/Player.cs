using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DragInputHandler input;
    [SerializeField] private DragIndicator indicator;
    [SerializeField] private PlayerMovement movement;

    private SpriteRenderer spriteRenderer;
    private ParticleSystem playerParticleSystem;

    private float timer = 0f;
    private float interval = 1f;

    private void Awake()
    {
        input.OnDragStart += indicator.OnDragStart;
        input.OnDragMove += indicator.OnDragMove;
        input.OnDragEnd += indicator.OnDragEnd;
        input.OnDragEnd += movement.OnDragEnd;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        //  ����� �� �ҷ�����
        var savedColor = GameManager.Instance.NowPlayerData.SavedColor.ToUnityColor();

        ApplyColor(savedColor);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            //  ���� ���� ����
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            // ����
            ApplyColor(randomColor);

            //  ����
            GameManager.Instance.NowPlayerData.SavedColor = new SerializableColor(randomColor);
        }
    }

    private void ApplyColor(Color color)
    {
        if (spriteRenderer != null)
            spriteRenderer.color = color;

        if (playerParticleSystem != null)
        {
            var main = playerParticleSystem.main;
            main.startColor = color;
        }
    }
}
