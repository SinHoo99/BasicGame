using System;
using UnityEngine;

public class Test : MonoBehaviour
{

    public void GoMainScene()
    {
       SceneLoadManager.LoadScene(2);
    }

    public void GoStartScene()
    {
        SceneLoadManager.LoadScene(0);
    }

    public void GoStoreScene()
    {
        SceneLoadManager.LoadScene(3);
    }
}
