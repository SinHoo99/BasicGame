using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DragInputHandler input;
    [SerializeField] private DragIndicator indicator;
    [SerializeField] private PlayerMovement movement;

    private GameObject PlayerSO => GameManager.Instance.GetPlayerSOData().PlayerPrefab;
    private Color playerColor;
    private ParticleSystem playerParticleSystem;

    private void Awake()
    {
        input.OnDragStart += indicator.OnDragStart;
        input.OnDragMove += indicator.OnDragMove;
        input.OnDragEnd += indicator.OnDragEnd;
        input.OnDragEnd += movement.OnDragEnd;
    }

    private void Start()
    {
        playerColor = PlayerSO.GetComponentInChildren<Color>();
        playerParticleSystem = PlayerSO.GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        
    }
}
