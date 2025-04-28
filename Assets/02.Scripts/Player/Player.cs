using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DragInputHandler input;
    [SerializeField] private DragIndicator indicator;
    [SerializeField] private PlayerMovement movement;

    private ParticleSystem playerParticleSystem;
    private CapsuleCollider2D capsuleCollider;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject CoinEffect;

    private void Awake()
    {
        input.OnDragStart += indicator.OnDragStart;
        input.OnDragMove += indicator.OnDragMove;
        input.OnDragEnd += indicator.OnDragEnd;
        input.OnDragEnd += movement.OnDragEnd;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerParticleSystem = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        EventBus.Subscribe<PlayerJumpEvent>(OnJump);
        EventBus.Subscribe<PlayerFallEvent>(OnFall);
        EventBus.Subscribe<PlayerFlipEvent>(OnFlip);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerJumpEvent>(OnJump);
        EventBus.Unsubscribe<PlayerFallEvent>(OnFall);
        EventBus.Unsubscribe<PlayerFlipEvent>(OnFlip);
    }

    private void Start()
    {
        ColorID selectedID = GameManager.Instance.NowPlayerData.NowColorID;
        ColorData data = GameManager.Instance.GetColorData(selectedID);
        ApplyColor(data.GetUnityColor());
    }
    private void OnJump(PlayerJumpEvent e)
    {
        animator.SetBool("IsJumping", true);
        animator.SetBool("IsFalling", false);
    }

    private void OnFall(PlayerFallEvent e)
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", true);
    }

    private void OnFlip(PlayerFlipEvent e)
    {
        spriteRenderer.flipX = e.isFacingLeft;
    }

    private void ApplyColor(Color color)
    {
        if (playerParticleSystem != null)
        {
            var main = playerParticleSystem.main;
            main.startColor = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin Test");
            CoinEffect.SetActive(true);
        }
    }
}
