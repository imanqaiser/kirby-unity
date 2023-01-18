using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthGesture : MonoBehaviour
{

     Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(Blink());
    }

    void Update()
    {
    }
    private IEnumerator Blink()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f)); // time between mouth moves 
            rend.material.SetTextureOffset("_BaseMap", new Vector2(0,.33f));
            yield return new WaitForSeconds(0.5f); 
            rend.material.SetTextureOffset("_BaseMap", new Vector2(0, 0.66f));
        }
    }
}
