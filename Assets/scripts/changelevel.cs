using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changelevel : MonoBehaviour
{

    public string levelToLoad; //  escena que se cargará

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
        if (collision.GetComponent<MarioScript>())
        {
            // cambia la escena
            GameManager.instance.LoadScene(levelToLoad);
        }
    }
}
