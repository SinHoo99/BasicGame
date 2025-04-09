using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DragInputHandler input;
    [SerializeField] private DragIndicator indicator;
    [SerializeField] private PlayerMovement movement;

    private SpriteRenderer spriteRenderer;
    private ParticleSystem playerParticleSystem;

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
        ColorID selectedID = GameManager.Instance.NowPlayerData.NowColorID;
        ColorData data = GameManager.Instance.GetColorData(selectedID);
        ApplyColor(data.GetUnityColor());
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
