using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, rayDistance, jumpForce;
    public LayerMask groundMask; // MASCARA DE COLISIONES con la que queremos que el rayo se quiera chocar

    private Rigidbody2D rb;
    private SpriteRenderer _rend;
    private Animator _animator;
    private Vector2 dir;
    private bool _intentionToJump;//pueda o no que tenga la intencion de saltar
    public AudioClip jumpClip; //audio de salto
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update() //direccion del personaje en x y flip
    {
        print(GameManager.instance.GetTime()); //para que sea accesible desde cualquier parte del codigo

        dir = Vector2.zero;
        if(Input.GetKey(rightKey)) //si pulsas flecha derecha se mueve a la derecha
        {
            _rend.flipX = false;
            dir = Vector2.right;
        }
        else if(Input.GetKey(leftKey)) //si pulsas flecha izquierda se mueve izquierda
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
        }

        _intentionToJump = false; //si pulsas espacio el personaje salta
        if(Input.GetKey(jumpKey))
        {
            _intentionToJump = true;
        }

        //ANIMACIONES
        if(dir != Vector2.zero)
        {
            //estamos andando
            _animator.SetBool("iswalking", true);
        }
        else
        {
            //estamos paarados
            _animator.SetBool("iswalking", false);
        }
    }

    private void FixedUpdate()
    {
        bool grnd = IsGrounded();
        //if(dir != Vector2.zero) 
        {
            float currentYVel = rb.velocity.y; // si estas en movimiento y caes, caes a la misma velocidad que te mueves.
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel; // almacenar la velocidad en y para que no flote
            rb.velocity = nVel;
            
        }
        
        if(_intentionToJump && IsGrounded()) //lo mete en el fixe update por fisicas
        {
            _animator.Play("jump");// necesitamos esto ya que somos nosotros los que iniciamos el salto
            rb.velocity = new Vector2(rb.velocity.x, 0); // sirve para que el personaje mantenga siempre la misma potencia de salto  (100,-100)
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale * rb.drag, ForceMode2D.Impulse); // rb.drag es la linea de rozqamiento, por lo que al multiplicar por ella no desliza el personaje.
            
            AudioManager.instance.PlayAudio(jumpClip, "jumpSound");
        }
        _animator.SetBool("walkanim", grnd);
    }

    

    private bool IsGrounded() // se lanza un rayo desde el personaje hacia bajo y va a detectar la mascara de colisiones que hemos establecido(detectar el suelo)
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        if (collision)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos() // identificamos el rayo
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

   



}

