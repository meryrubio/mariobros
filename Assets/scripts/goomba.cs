using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goomba : MonoBehaviour
{
    public float speed;
    public Transform esqueleto;
    private SpriteRenderer _rend;// se asigna el Transform del esqueleto desde el inspector en el script del goomba
    public AudioClip deadClip; //audio de muerte

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        if (esqueleto != null) //asegurarse de que la variable esqueleto (que es del tipo Transform) no sea nula
        {
            // Compara las posiciones en el eje X y mueve al Goomba hacia el esqueleto
            if (transform.position.x < esqueleto.position.x) 
            {
                // Mueve hacia la derecha
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                _rend.flipX = false;
            }
            // si la posisicion del goomba es menor que la del esqueleto (es decir el goomba esta a la izquierda del esqueleto) queremos que se mueva a la derecha

            else if (transform.position.x > esqueleto.position.x)
            {
                // Mueve hacia la izquierda
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                _rend.flipX = true;
            }
            // si la posisicion del goomba es mayor que la del esqueleto (es decir el goomba esta a la derecha del esqueleto) queremos que se mueva a la izquierda
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MarioScript>()) // lo que se choca con el goomba es el esqueleto
        {
            // Reinicia y limpia la escena de objetos y audios.
            GameManager.instance.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.instance.ResetTime();// el contador se reinicia cada vez que mario muere

            AudioManager.instance.PlayAudio(deadClip, "deadSound"); //cuando mario choca con el goomba se reproduce sonido de muerte

        }
    }
    
    // otra forma para que el goomba siga a mario
    // es declarar las variables private GameObject target y public float speed;
    // y luego en el Start:
    // target = FindObjectOfType<MarioScript>.gameObject;



}
