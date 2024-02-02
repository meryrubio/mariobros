using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<GameObject> audioList;// todos los obljetos que esten sonando nos los vamos a guardar

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioList = new List<GameObject>();
    }

    private void Start()
    {

    }


    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f) // isLoop y float volume --> parametros por defectos (valores por defecto), tienen que ir al final y no pueden estar intercalados
    {
        GameObject audioObject = new GameObject(gameObjectName); // para darle nombre e identificarlo en la escena 
        audioObject.transform.SetParent(transform); // todos los objetos del audio que se van creando sean hijos del audio manager.
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();// le añado el componente de AudioSource 
        audioSourceComponent.clip = audioClip; // asignamos el clip al compenente y el clip que asignamos es nuestro metodo
        audioSourceComponent.volume = volume; // ""
        audioSourceComponent.loop = isLoop; // ""

        audioSourceComponent.Play(); //inicie el audio

        audioList.Add(audioObject); // llevar un seguimiento de los objetos que estan sonando en la escena


        return audioSourceComponent; // porsiaca  desde otros componentes queremos utilizar otros parametros del AudioSource
    }
    
    public void ClearAudios()
    {
        // por todos audios de la lista tenemos que destruirlos a todos, es un recorrido --> foreach
        foreach(GameObject audioObject in audioList)
        {
            Destroy(audioObject);
        }

        audioList.Clear(); //borra todo el contenido de la lista ( por qué se queda memoria y hay que borrarla tambien)
    }
}
