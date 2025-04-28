using UnityEngine;

public class GameOverPopUp : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.PlaySFX(SFX.GameOver);
    }
}
