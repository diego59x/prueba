using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 *  Este SCRIPT se puede usar para todas las puertas 
 *  Desde unity se debe colocar el nombre del nivel
 *  y agregar el texto 
 * 
 */
public class OpenDoor : MonoBehaviour
{
    public Text text;// aviso de que debe pulsar para entrar
    public string levelName;//nombre del nivel
    private bool inDoor = false; // Para saber si estamos en la puerta

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mostrar el texto para que presione la tecla enter para entrar a la puerta
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mostrar el texto para que presione la tecla enter para entrar a la puerta
            text.gameObject.SetActive(false);
            inDoor = false;
        }
    }
    private void Update()
    {
        //constantemente vamos viendo si el personaje esta sobre una puerta y a presionado la tecla enter
        if(inDoor && Input.GetKey("b"))
        {
            SceneManager.LoadScene(levelName);
        }
    }

}
