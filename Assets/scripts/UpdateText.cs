using System.Collections;
using System.Collections.Generic;
using TMPro; //avisar al código de que vas a utlizar otro código que esta en otra localización
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameManager.GameManagerVariables variable;

    private TMP_Text textComponent;

    // Start is called before the first frame update
    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (variable) //
        {
            case GameManager.GameManagerVariables.TIME:
                textComponent.text = "Time: " + GameManager.instance.GetTime();
                break;
            case GameManager.GameManagerVariables.POINTS:
                textComponent.text = "Points: " + GameManager.instance.GetPoints();
                break;
            default:
                break;

        }
        //el switch seria lo mismo que utilizar lo siguiente; al ser una varibale enumerada es mejor utilizar un switch
        //if(variable == GameManager.GameManagerVariables.TIME)
        //{

        //}
        //else if(variable == GameManager.GameManagerVariables.POINTS)
        //{

        //}
        //else
        //{

        //}
    }

    // EL EVENT SYSTEM se crea automaticamente cuando creamos un canvas, habilita que se detecte los eventos del usuario(clicks, scrolls..) sobre los eventos de la interfaz, NUNCA SE TOCA!!

    // cuando empieza por ON casi siempre va a ser un evento (ej: OnClick)
}
