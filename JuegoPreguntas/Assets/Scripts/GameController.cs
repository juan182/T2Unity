using models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    string respuestaPM;
    string respuestaFV;

    int perdidas;
    int ganadas;
    int round;

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

    //Round
    public TextMeshProUGUI roundT;


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

    public TMP_InputField inputField;

    public bool facil;

    public object preguntaActual;

    //Audio
    public AudioSource audioSource;
    public AudioClip victoria;
    public AudioClip derrota;

    
    
    


    // Start is called before the first frame update
    void Start()
    {

        Registro.Inicializar();

        
        ganadas = 0;
        perdidas = 0;
        round = 0;

        roundT.gameObject.SetActive(true);

        PreguntasAleatorias();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreguntasAleatorias()
    {
        preguntaActual = Registro.mostrarOtraPregunta();

        panelPrincipal.SetActive(false);
        panelPreguntaFV.SetActive(false);
        panelPreguntaA.SetActive(false);
        panelFin.SetActive(false);


        if (preguntaActual is PreguntasMultiples)
        {
            mostrarPreguntasMultiples((PreguntasMultiples)preguntaActual);

            var dificultad = (PreguntasMultiples)preguntaActual;
            if (dificultad.Dificultad == "facil") round = 1;
            else if (dificultad.Dificultad == "dificil") round = 2;

            panelPrincipal.SetActive(true);
            panelPreguntaFV.SetActive(false);
            panelPreguntaA.SetActive(false);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(true);
        }
        else if (preguntaActual is PreguntasFV)
        {
            mostrarPreguntasFV((PreguntasFV)preguntaActual);

            var dificultad = (PreguntasFV)preguntaActual;
            if (dificultad.Dificultad == "facil") round = 1;
            else if (dificultad.Dificultad == "dificil") round = 2;

            panelPrincipal.SetActive(false);
            panelPreguntaFV.SetActive(true);
            panelPreguntaA.SetActive(false);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(true);
        }
        else if (preguntaActual is PreguntasAbiertas)
        {
            mostrarPreguntasAbiertas((PreguntasAbiertas)preguntaActual);

            var dificultad = (PreguntasAbiertas)preguntaActual;
            if (dificultad.Dificultad == "facil") round = 1;
            else if (dificultad.Dificultad == "dificil") round = 2;

            panelPrincipal.SetActive(false);
            panelPreguntaFV.SetActive(false);
            panelPreguntaA.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(true);
        }
        else
        {
            panelPrincipal.SetActive(false);
            panelPreguntaFV.SetActive(false);
            panelPreguntaA.SetActive(false);
            panelFin.SetActive(true);
            roundT.gameObject.SetActive(true);
            mostrarScore();
        }

        mostrarRound();
    }

    #region mostrar preguntas 
    public void mostrarPreguntasMultiples(PreguntasMultiples pregunta)
    {
        panelCorrecto.SetActive(false);
        panelIncorrecto.SetActive(false);
        panelPrincipal.SetActive(true);
        panelFin.SetActive(false);
        panelPreguntaFV.SetActive(false);
        panelPreguntaA.SetActive(false);

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
        panelPreguntaFV.SetActive(true);
        panelIncorrectoV.SetActive(false);
        panelCorrectoF.SetActive(false);
        panelPrincipal.SetActive(false);
        panelFin.SetActive(false);
        panelPreguntaA.SetActive(false);


        respuestaFV = pregunta.Respuesta;
        textVersiculoF.SetText(pregunta.Versiculo);
        textVersiculoV.SetText(pregunta.Versiculo);
        textPreguntaFV.SetText(pregunta.Pregunta);
        textRespuestaCF.SetText(pregunta.Respuesta);

    }

    public void mostrarPreguntasAbiertas(PreguntasAbiertas pregunta)
    {
        panelPreguntaFV.SetActive(false);
        panelPrincipal.SetActive(false);
        panelFin.SetActive(false);
        panelRespuestaA.SetActive(false);
        panelPreguntaA.SetActive(true);

        textPreguntaA.text = pregunta.Pregunta;

        textRespuestaA.SetText(pregunta.Respuesta);
        textVersiculoA.SetText(pregunta.Versiculo);
    }

    #endregion 

    

    public void mostrarScore()
    {
        panelPrincipal.SetActive(false);
        panelPreguntaFV.SetActive(false);
        panelPreguntaA.SetActive(false);
        panelFin.SetActive(true);
        roundT.gameObject.SetActive(false);

        textGanadas.SetText("Respuestas Correctas: " + ganadas.ToString());
        textPerdidas.SetText("Respuestas Incorrectas: " + perdidas.ToString());
    }

    public void mostrarRound()
    {
        roundT.text = "Round= "+round.ToString();

    }

    public void cerrarQuiz()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
            
    }

    public void botonRespuestaAbierta()
    {
        
        panelFin.SetActive(false);
        panelPrincipal.SetActive(false);
        panelPreguntaFV.SetActive(false);
        panelPreguntaA.SetActive(true);
        panelRespuestaA.SetActive(true);
        roundT.gameObject.SetActive(false);
        inputField.text = "";
    }

    public void comprobarRespuesta1()
    {
        if (textResp1.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 1");

            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 1");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            perdidas += 1;
        }
    }

    public void comprobarRespuesta2()
    {
        if (textResp2.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 2");
            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 2");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            perdidas += 1;

        }
    }

    public void comprobarRespuesta3()
    {
        if (textResp3.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 3");
            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 3");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            perdidas += 1;

        }
    }

    public void comprobarRespuesta4()
    {
        if (textResp4.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 4");
            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 4");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            perdidas += 1;

        }
    }

    public void comprobarRespuestaFalso()
    {
        if (textRespuestaF.text.Equals(respuestaFV))
        {
            panelPreguntaFV.SetActive(true);
            panelIncorrectoV.SetActive(false);
            panelCorrectoF.SetActive(true);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            Debug.Log("Respuesta Correcta es Falso");

            ganadas += 1;

        }
        else
        {
            panelPreguntaFV.SetActive(true);
            panelIncorrectoV.SetActive(true);
            panelCorrectoF.SetActive(false);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            Debug.Log("Respuesta incorrecta");

            perdidas += 1;

        }
    }

    public void comprobarRespuestaVerdadero()
    {
        if (textRespuestaV.text.Equals(respuestaFV))
        {
            Debug.Log("Respuesta correcta es Verdadero");

            panelPreguntaFV.SetActive(true);
            panelIncorrectoV.SetActive(false);
            panelCorrectoF.SetActive(true);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta incorrecta");

            panelPreguntaFV.SetActive(true);
            panelIncorrectoV.SetActive(true);
            panelCorrectoF.SetActive(false);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
            roundT.gameObject.SetActive(false);

            perdidas += 1;

        }
    }

    
}
