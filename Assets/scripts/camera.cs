using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public Transform player; // Referencia al transform del personaje
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        // la camara se centrara automaticamente en el personaje y si no esta centra lo hara en el reinicio de la partida.
       transform.position =Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, -5f), 5f * Time.deltaTime);
    }
}
