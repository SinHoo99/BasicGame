using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject SettingPopUp;
    public void GoMainScene()
    {
        SceneLoadManager.LoadScene(2);
        if (SettingPopUp != null && SettingPopUp.activeSelf)
        {
            SettingPopUp.SetActive(false);
        }
    }

    public void GoStartScene()
    {
        SceneLoadManager.LoadScene(0);
        SettingPopUp.SetActive(false);
    }

    public void GoStoreScene()
    {
        SceneLoadManager.LoadScene(3);
        SettingPopUp.SetActive(false);
    }
}
