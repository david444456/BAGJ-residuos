using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFin : MonoBehaviour
{
    [SerializeField] private int _pointExpected = 100;
    [SerializeField] private Slider _sliderStars;
    public Text puntajeTexto;

    private void Start()
    {
        _sliderStars.maxValue = _pointExpected;
    }

    public void Setup(int puntaje)
    {
        gameObject.SetActive(true);
        _sliderStars.value = puntaje;
        print(_sliderStars.value);
        puntajeTexto.text = puntaje.ToString() + " PUNTOS";
    }
}
