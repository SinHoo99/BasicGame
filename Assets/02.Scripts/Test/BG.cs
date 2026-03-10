
using UnityEngine;

public class BG : MonoBehaviour
{
    public void Exit()
    {
        transform.parent.gameObject.SetActive(false);
        GameManager.Instance.PlaySFX(SFX.Click);
    }
}
