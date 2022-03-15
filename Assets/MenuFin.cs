using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFin : MonoBehaviour
{
    public Text puntajeTexto;
    public void Setup(int puntaje)
    {
        gameObject.SetActive(true);
        puntajeTexto.text = puntaje.ToString() + " PUNTOS";
    }
}
