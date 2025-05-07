
using System.Collections;
using UnityEngine;

public class Planet : MonoBehaviour
{
   private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(RotatePlanet());
    }

    private IEnumerator RotatePlanet()
    {

        while (true)
        {
            transform.Rotate(Vector3.forward, 30f * Time.deltaTime);
            yield return null;
        }
    }
}
