using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioClip coinClip; //audio de moneda

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D( Collider2D other) // trigger porque lo quiero atravesar
    {
        if (other.gameObject.GetComponent<MarioScript>())
        {
            GameManager.instance.IncreaseScore(1); // llamamos al gamemanager para que el metodo de increase score pueda sumar los puntos de uno en uno (1) cundo coge una pocion.
            Destroy(gameObject);

            AudioManager.instance.PlayAudio(coinClip, "coinSound"); //se reproduce sonido de moneda
        }
        
       
    }
}
