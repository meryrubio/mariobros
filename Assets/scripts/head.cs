using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) //esto sirve para que cuando el esqueleto le pise ne la cabeza el goomba se muere
    {
        if (collision.gameObject.GetComponent<MarioScript>())
        {
            Destroy(transform.parent.gameObject);// parent se refiere al goomba
        }
    }
}
//SINGLENTON tiene dos caracteristicas, una es que solo tiene una instancia de esa clase en todo el juego, y la otra es que esa instancia es accesible a todo el mundo
