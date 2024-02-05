using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    private SpriteRenderer _rend;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
       

    }

    IEnumerator FadeOut() // para que el objeto desaparezca poco a poco 
    {
        Color color = _rend.color; // para guardarnos los parametros del color original de objeto 
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f) //para que el alpha se vaya reduciendo poco a poco.
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f); //devuelve el control a unity esos 0.2 segundos
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() // para que el objeto aparezca poco a poco 
    {
        Color color = _rend.color; // para guardarnos los parametros del color original de objeto 
        for (float alpha = 0f; alpha <= 1; alpha += 0.01f) //para que el alpha se vaya aumentando poco a poco.
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f); //devuelve el control a unity esos 0.2 segundos
        }
        StartCoroutine(FadeOut());
    }
}