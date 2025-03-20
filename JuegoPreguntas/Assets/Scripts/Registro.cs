using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    //Listas
    string lineaLeida = "";
    List<PreguntasMultiples> listaPreguntasMultiples;
    List<PreguntasMultiples> listaPreguntasMultiplesFacil;
    List<PreguntasMultiples> listaPreguntasMultiplesDificil;
    List<PreguntasFV> listaPreguntasFV;
    List<PreguntasFV> listaPreguntasFVFacil;
    List<PreguntasFV> listaPreguntasFVDificil;
    List<PreguntasAbiertas> listaPreguntasAbierta;
    List<PreguntasAbiertas> listaPreguntasAbiertasFacil;
    List<PreguntasAbiertas> listaPreguntasAbiertasDificil;

    string respuestaPM;
    string respuestaFV;

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
    // Start is called before the first frame update


    public void mostrarPreguntasMultiples(PreguntasMultiples pregunta)
    {
        textPregunta.text = pregunta.Pregunta;
        textResp1.text = pregunta.Respuesta1;
        textResp2.text = pregunta.Respuesta2;
        textResp3.text = pregunta.Respuesta3;
        textResp4.text = pregunta.Respuesta4;
        respuestaPM = pregunta.RespuestaCorrecta;
        textVersC.SetText(pregunta.Versiculo);
        textVersI.SetText(pregunta.Versiculo);
        textRespuestaC.SetText("La respuesta correcta es: " + pregunta.RespuestaCorrecta);

    }

    public void mostrarPreguntasFV(PreguntasFV pregunta)
    { 
        respuestaFV = pregunta.Respuesta;
        textVersiculoF.SetText(pregunta.Versiculo);
        textVersiculoV.SetText(pregunta.Versiculo);
        textPreguntaFV.SetText(pregunta.Pregunta);
        textRespuestaCF.SetText(pregunta.Respuesta);

    }

    public void mostrarPreguntasAbiertas(PreguntasAbiertas pregunta)
    {
        textPreguntaA.text = pregunta.Pregunta;

        textRespuestaA.SetText(pregunta.Respuesta);
        textVersiculoA.SetText(pregunta.Versiculo);
    }
}
