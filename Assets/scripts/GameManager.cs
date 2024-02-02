using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //este script controla todo, funcionalidad y variabbles

    public static GameManager instance; // accesible a todo (variable estática) SINGLETON
    public enum GameManagerVariables { TIME, POINTS}; // tipo enum (enumerar) para facilitar la lectura de código, time seria 0, points 1

    private float time;
    private int points;

    private void Awake()
    {
        if (!instance)// si instance no tiene info
        {
            instance = this; //si isma llega a la fiesta y ve que no hay nadie guapo isma se queda en la fiesta / instance se asigna a este objeto
            DontDestroyOnLoad(gameObject);// para que no se destruya en la carga de escenas
        }
        else // si ya hay alguin mas guapo antes que isma / si instance tiene info
        {
            Destroy(gameObject); // isma se va / se destruye el gameobject, para que no haya dos o mas gms en el juego
        }
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
    }

    //getter (es para obtener el valor de esa variable)
    public float GetTime()
    {
        return time;
    }

    public int GetPoints()
    {
        return points;
    }

    //setter
    public void SetPoints(int value)
    {
        points = value;
    }

    //callback -- funcion que se va  a llamar en el onclick() de los botones
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        AudioManager.instance.ClearAudios(); // oye, audioManager, limpia todos los sonidos que estan sonando
    }

    public void ExitGame()
    {
        Debug.Log("EXIT!!");
        Application.Quit();// cierra la aplicación
    }
}
