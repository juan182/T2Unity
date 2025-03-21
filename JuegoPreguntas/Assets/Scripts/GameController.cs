using models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    // Start is called before the first frame update

    string respuestaPM;
    string respuestaFV;
    

    int perdidas;
    int ganadas;


    //PreguntasMultiples
    public TextMeshProUGUI textPregunta;
    public TextMeshProUGUI textResp1;
    public TextMeshProUGUI textResp2;
    public TextMeshProUGUI textResp3;
    public TextMeshProUGUI textResp4;
    public TextMeshProUGUI textVersC;
    public TextMeshProUGUI textVersI;
    public TextMeshProUGUI textRespuestaC;

    //FalsoVerdadero
    public TextMeshProUGUI textVersiculoF;
    public TextMeshProUGUI textVersiculoV;
    public TextMeshProUGUI textRespuestaF;
    public TextMeshProUGUI textRespuestaV;
    public TextMeshProUGUI textPreguntaFV;
    public TextMeshProUGUI textRespuestaCF;

    //PreguntasAbiertas
    public TextMeshProUGUI textPreguntaA;
    public TextMeshProUGUI textRespuestaA;
    public TextMeshProUGUI textVersiculoA;

    //PanelFinal
    public TextMeshProUGUI textGanadas;
    public TextMeshProUGUI textPerdidas;


    //Paneles
    public GameObject panelCorrecto;
    public GameObject panelIncorrecto;
    public GameObject panelPrincipal;

    public GameObject panelFin;

    public GameObject panelPreguntaFV;
    public GameObject panelCorrectoF;
    public GameObject panelIncorrectoV;

    public GameObject panelPreguntaA;
    public GameObject panelRespuestaA;

    public Button continuar;

    public bool facil;
    public Registro registro;

    public object preguntaActual;


    void Start()
    {
        PreguntasAleatorias();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreguntasAleatorias()
    {
        preguntaActual = registro.mostrarOtraPregunta();

        if (preguntaActual == null)
        {
            panelPrincipal.SetActive(false);
            panelPreguntaFV.SetActive(false);
            panelPreguntaA.SetActive(false);
            panelFin.SetActive(true);

            mostrarScore();
        }

        panelPrincipal.SetActive(false);
        panelPreguntaFV.SetActive(false);
        panelPreguntaA.SetActive(false);
        panelFin.SetActive(false);

        if(preguntaActual is PreguntasMultiples)
        {
            mostrarPreguntasMultiples((PreguntasMultiples)preguntaActual);
        }
        else if(preguntaActual is PreguntasFV)
        {
            mostrarPreguntasFV((PreguntasFV)preguntaActual);
        }
        else if(preguntaActual is PreguntasAbiertas)
        {
            mostrarPreguntasAbiertas((PreguntasAbiertas)preguntaActual);
        }
    }
    

}
