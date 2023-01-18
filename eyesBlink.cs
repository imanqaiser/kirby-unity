using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesBlink : MonoBehaviour
{

    float offset = 0.54f;
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
            yield return new WaitForSeconds(Random.Range(2f, 4f)); // time between blink 
            rend.material.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
            yield return new WaitForSeconds(0.25f); // eyes closed time
            rend.material.SetTextureOffset("_BaseMap", new Vector2(0, 0));// reset - open eyes
        }
    }
}
