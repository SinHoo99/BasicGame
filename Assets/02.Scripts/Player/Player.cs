using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DragInputHandler input;
    [SerializeField] private DragIndicator indicator;
    [SerializeField] private PlayerMovement movement;

    private ParticleSystem playerParticleSystem;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        if (input != null && indicator != null && movement != null)
        {
            input.OnDragStart += indicator.OnDragStart;
            input.OnDragMove += indicator.OnDragMove;
            input.OnDragEnd += indicator.OnDragEnd;
            input.OnDragEnd += movement.OnDragEnd;
            input.OnTap += HandleTap;

            movement.SetInputHandler(input);
        }
        else
        {
            Debug.LogError("Player: DragInputHandler, DragIndicator, PlayerMovement 연결이 안 되어 있습니다.");
        }


        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerParticleSystem = GetComponentInChildren<ParticleSystem>();
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
        if (GameManager.Instance != null)
        {
            ColorID selectedID = GameManager.Instance.NowPlayerData.NowColorID;
            ColorData data = GameManager.Instance.GetColorData(selectedID);
            ApplyColor(data.GetUnityColor());
        }
        else
        {
            Debug.LogError("Player: GameManager.Instance가 존재하지 않습니다.");
        }
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

    private void HandleTap(Vector2 tapPosition)
    {
        // 탭 위치에 따라 공격, 회피 등 결정
        Debug.Log($"탭 감지됨! 위치: {tapPosition}");

        // 예: 오른쪽 반 → 공격, 왼쪽 반 → 회피
        float screenCenter = Screen.width / 2f;
        if (Input.mousePosition.x > screenCenter)
        {
            Debug.Log("공격!");
            EventBus.Publish(new PlayerAttackEvent());
        }
        else
        {
            Debug.Log("회피!");
            EventBus.Publish(new PlayerDodgeEvent());
        }
    }
}
