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
        // Verifica si la colisión es con el esqueleto.
        if(collision.GetComponent<MarioScript>())
        {
            // Reinicia la escena.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
