using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathzone : MonoBehaviour
{

    public AudioClip deadClip; //audio de muerte

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la colisión es con el esqueleto.
        if(collision.GetComponent<MarioScript>())
        {
            // Reinicia y limpia la escena de objetos y audios.
            GameManager.instance.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.instance.ResetTime();// el contador se reinicia cada vez que mario muere

            AudioManager.instance.PlayAudio(deadClip, "deadSound"); //se reproduce sonido de muerte
        }
    }
}
