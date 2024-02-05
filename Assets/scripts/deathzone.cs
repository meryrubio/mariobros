using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathzone : MonoBehaviour
{
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
        // Verifica si la colisi�n es con el esqueleto.
        if(collision.GetComponent<MarioScript>())
        {
            // Reinicia y limpia la escena de objetos y audios.
            GameManager.instance.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
