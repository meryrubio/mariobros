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
