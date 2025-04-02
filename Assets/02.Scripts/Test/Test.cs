using System;
using UnityEngine;

public class Test : MonoBehaviour
{

    public void Testing()
    {
       SceneLoadManager.LoadScene(2);
    }

    public void GoStartScene()
    {
        SceneLoadManager.LoadScene(0);
    }
}
