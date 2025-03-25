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
        registro.LecturaPreguntasAbiertas();
        registro.LecturaPreguntasFV();
        registro.LecturaPreguntasMultiples();
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

    #region Mostrar Pregunta
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

        textGanadas.SetText("Respuestas Correctas: " + ganadas.ToString());
        textPerdidas.SetText("Respuestas Incorrectas: " + perdidas.ToString());
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

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 1");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);

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

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 2");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);

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

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 3");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);

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

            ganadas += 1;

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 4");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(true);
            panelFin.SetActive(false);

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

            perdidas += 1;

        }
    }
}
