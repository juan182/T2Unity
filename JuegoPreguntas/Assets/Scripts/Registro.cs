using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using TMPro;
using System.IO;
using System;

public class Registro 
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

    public object mostrarOtraPregunta()
    {


        List<System.Object> preguntasDisponibles = new List<System.Object>();
        

        preguntasDisponibles.AddRange(listaPreguntasAbiertasFacil);
        preguntasDisponibles.AddRange(listaPreguntasFVFacil);
        preguntasDisponibles.AddRange(listaPreguntasMultiplesFacil);

        if (preguntasDisponibles.Count == 0)
        {
            preguntasDisponibles.AddRange(listaPreguntasAbiertasDificil);
            preguntasDisponibles.AddRange(listaPreguntasMultiplesDificil);
            preguntasDisponibles.AddRange(listaPreguntasFVDificil);
        }


        if (preguntasDisponibles.Count > 0)
        {
            int i = UnityEngine.Random.Range(0, preguntasDisponibles.Count);
            return preguntasDisponibles[i];

            object preguntaSeleccionada = preguntasDisponibles[i];

            // Eliminar la pregunta de la lista original
            if (preguntaSeleccionada is PreguntasAbiertas)
            {
                listaPreguntasAbiertasFacil.Remove(preguntaSeleccionada as PreguntasAbiertas);
                listaPreguntasAbiertasDificil.Remove(preguntaSeleccionada as PreguntasAbiertas);
            }
            else if (preguntaSeleccionada is PreguntasFV)
            {
                listaPreguntasFVFacil.Remove(preguntaSeleccionada as PreguntasFV);
                listaPreguntasFVDificil.Remove(preguntaSeleccionada as PreguntasFV);
            }
            else if (preguntaSeleccionada is PreguntasMultiples)
            {
                listaPreguntasMultiplesFacil.Remove(preguntaSeleccionada as PreguntasMultiples);
                listaPreguntasMultiplesDificil.Remove(preguntaSeleccionada as PreguntasMultiples);
            }
            return preguntaSeleccionada;
        }
        else
        {
            Debug.Log("No hay mas preguntas");
            return null;
        }
    }




    public void LecturaPreguntasAbiertas()
    {
        try
        {
            StreamReader srlpa = new StreamReader("Assets/Files/ArchivoPreguntasAbiertas.txt");
            while ((lineaLeida = srlpa.ReadLine()) != null)
            {
                string[] lineaPartida = lineaLeida.Split("-");
                string preguntaA = lineaPartida[0];
                string respuestaA = lineaPartida[1];
                string versiculoA = lineaPartida[2];
                string dificultad = lineaPartida[3];

                PreguntasAbiertas objPA = new PreguntasAbiertas(preguntaA, respuestaA, versiculoA, dificultad);

                listaPreguntasAbierta.Add(objPA);
                if (dificultad.Equals("facil"))
                {
                    listaPreguntasAbiertasFacil.Add(objPA);
                }
                else
                {
                    listaPreguntasAbiertasDificil.Add(objPA);
                }
            }
            Debug.Log("El tamaño de la lista preguntas abiertas es: " + listaPreguntasAbierta.Count);
        }
        catch (Exception e)
        {
            Debug.Log("Error!!!" + e.ToString());
        }
        finally
        {
            Debug.Log("Executing finally block.");
        }
    }

    public void LecturaPreguntasFV()
    {
        try
        {
            StreamReader srlvf = new StreamReader("Assets/Files/preguntasFalso_Verdadero.txt");
            while ((lineaLeida = srlvf.ReadLine()) != null)
            {
                string[] lineaPartida = lineaLeida.Split("-");
                string preguntaVf = lineaPartida[0];
                string respuestaVf = lineaPartida[1];
                string versiculoVf = lineaPartida[2];
                string dificultadVf = lineaPartida[3];

                PreguntasFV objPFV = new PreguntasFV(preguntaVf, respuestaVf, versiculoVf, dificultadVf);

                listaPreguntasFV.Add(objPFV);

                if (dificultadVf.Equals("facil"))
                {
                    listaPreguntasFVFacil.Add(objPFV);
                }
                else
                {
                    listaPreguntasFVDificil.Add(objPFV);
                }

            }
            Debug.Log("El tamaño de la lista es: " + listaPreguntasFV.Count);
        }
        catch (Exception e)
        {
            Debug.Log("Error!!!" + e.ToString());
        }
        finally
        {
            Debug.Log("Executing finally block.");
        }
    }


    public void LecturaPreguntasMultiples()
    {
        try
        {
            StreamReader srl = new StreamReader("Assets/Files/ArchivoPreguntasM.txt");
            while ((lineaLeida = srl.ReadLine()) != null)
            {
                string[] lineaPartida = lineaLeida.Split("-");
                string pregunta = lineaPartida[0];
                string respuesta1 = lineaPartida[1];
                string respuesta2 = lineaPartida[2];
                string respuesta3 = lineaPartida[3];
                string respuesta4 = lineaPartida[4];
                string respuestaCorrecta = lineaPartida[5];
                string versiculo = lineaPartida[6];
                string dificultad = lineaPartida[7];

                PreguntasMultiples objPM = new PreguntasMultiples(pregunta, respuesta1, respuesta2,
                    respuesta3, respuesta4, respuestaCorrecta, versiculo, dificultad);

                listaPreguntasMultiples.Add(objPM);

                if (dificultad.Equals("facil"))
                {
                    listaPreguntasMultiplesFacil.Add(objPM);
                }
                else
                {
                    listaPreguntasMultiplesDificil.Add(objPM);
                }
            }
            Debug.Log("El tamaño de lista es " + listaPreguntasMultiples.Count);

        }
        catch (Exception e)
        {
            Debug.Log("ERROR!!!!" + e.ToString());
        }
        finally
        {
            Debug.Log("Executing finally block.");
        }

    }
}
