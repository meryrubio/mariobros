using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, rayDistance, jumpForce;
    public LayerMask groundMask; // MASCARA DE COLISIONES con la que queremos que el rayo se quiera chocar

    private Rigidbody2D rb;
    private Vector2 dir;
    private bool _intentionToJump;//pueda o no que tenga la intencion de saltar

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector2.zero;
        if(Input.GetKey(rightKey))
        {
            dir = Vector2.right;
        }
        else if(Input.GetKey(leftKey))
        {
            dir = new Vector2(-1, 0);
        }

        _intentionToJump = false;
        if(Input.GetKey(jumpKey))
        {
            _intentionToJump = true;
        }
    }

    private void FixedUpdate()
    {
        if(dir != Vector2.zero)
        {
            float currentYVel = rb.velocity.y; // si estas en movimiento y caes, caigas a la misma velocidad que te mueves.
            Vector2 nVel = dir * speed;
            rb.velocity = nVel;
            
        }
        
        if(_intentionToJump && IsGrounded()) //lo mete en el fixe update por fisicas
        {
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse);
        }
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
