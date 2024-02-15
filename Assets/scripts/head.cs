using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    public AudioClip headClip;
    private void OnTriggerEnter2D(Collider2D collision) //esto sirve para que cuando el esqueleto le pise ne la cabeza el goomba se muere
    {
        if (collision.gameObject.GetComponent<MarioScript>())
        {
            GameManager.instance.IncreaseScore(5); // llamamos al gamemanager para que el metodo de increase score pueda sumar los puntos, en este caso 5 ya que matar al goomba vale mas.
            Destroy(transform.parent.gameObject);// parent se refiere al goomba

            AudioManager.instance.PlayAudio(headClip, "headSound");
        }
    }
}
//SINGLENTON tiene dos caracteristicas, una es que solo tiene una instancia de esa clase en todo el juego, y la otra es que esa instancia es accesible a todo el mundo
