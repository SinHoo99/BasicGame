using UnityEngine;

public class StoreButton : MonoBehaviour
{
    public void GoToMain()
    {
        GameManager.Instance.PlayBGM(BGM.MainScene);
        SceneLoadManager.LoadScene(2);
    } 
}
