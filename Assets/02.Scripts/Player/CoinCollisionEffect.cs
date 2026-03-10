using UnityEngine;

public class CoinCollisionEffect : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, -1, 0f);
    }
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
