using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine.UI;
public class controlFormularios : MonoBehaviour
{
    GameObject[] listaPreguntas = new GameObject[7];
    Button botonContinuarButton;
    Text datoIngresadoTxt;
    int posicionPregunta=0;
    public GameObject[] listaBotonesNegro = new GameObject[4];
    public GameObject[] listaSombrasBotones = new GameObject[6];
    public GameObject btnContinuar, btnFin;
    //variables para datos de usuario
    string nombreUsuario,nombre, estadoAnimo, genero;
    int edad;
    bool medicamentos, psicologo;
    //al inicio de la ejecucion del script estebuscara los objetos indicados y los asignara a sus variables establecidas
    private void Start()
    {       
        botonContinuarButton = GameObject.FindGameObjectWithTag("botonContinuar").GetComponent<Button>();
        for(int i = 0; i < listaPreguntas.Length; i++)
        {
            listaPreguntas[i] = GameObject.Find("contenedor"+(i + 1));
            if (i > 0)
            {
                listaPreguntas[i].SetActive(false); 
            }
        }
    }
    //realizar la validacion para el nombre que haya ingresado
    public void validarNombre()
    {
        datoIngresadoTxt = GameObject.Find("TextNombre").GetComponent<Text>();
        nombreUsuario = datoIngresadoTxt.text;
        nombre = datoIngresadoTxt.text;
        if (nombreUsuario.Length > 1)
        {
            activarBotonContinuar();
        }
        else
        {
            desactivarBotonContinuar();
        }
    }
    //realiazar una validacion de que los datos ingresados sean correspondientes por lo menos a mas de 3 años
    public void validarEdad()
    {
        datoIngresadoTxt = GameObject.Find("txtEdad").GetComponent<Text>();
        edad = int.Parse(datoIngresadoTxt.text);
        if (edad>3)
        {
            activarBotonContinuar();
        }
        else
        {
            desactivarBotonContinuar();
        }
    }
    //oscurecer uno u otro boton dependiendo de cual se selccine
    public void diferenciarBotonSeleccionado(int botonPulsado)
    {
        GameObject[] listaBotones = new GameObject[4];
        
        listaBotones = GameObject.FindGameObjectsWithTag("GameController");
        for (int i = 0; i < listaBotones.Length; i++)
        {            
            if (botonPulsado == 0)
            {
                listaBotonesNegro[1].SetActive(true);
                listaBotonesNegro[2].SetActive(true);
                listaBotonesNegro[3].SetActive(true);
                listaBotonesNegro[0].SetActive(false);
            }
            if (botonPulsado == 1)
            {
                listaBotonesNegro[0].SetActive(true);
                listaBotonesNegro[2].SetActive(true);
                listaBotonesNegro[3].SetActive(true);
                listaBotonesNegro[1].SetActive(false);
            }
            if (botonPulsado == 2)
            {
                listaBotonesNegro[1].SetActive(true);
                listaBotonesNegro[0].SetActive(true);
                listaBotonesNegro[3].SetActive(true);
                listaBotonesNegro[2].SetActive(false);
            }
            if (botonPulsado == 3)
            {
                listaBotonesNegro[1].SetActive(true);
                listaBotonesNegro[2].SetActive(true);
                listaBotonesNegro[0].SetActive(true);
                listaBotonesNegro[3].SetActive(false);
            }
        }        
        activarBotonContinuar();
        guardarDatosEstadoAnimo(botonPulsado);
    }        
    //almacenar en una variable el estado de animo
    void guardarDatosEstadoAnimo(int estado)
    {
        switch (estado)
        {
            case 0:
                estadoAnimo = "Feliz";
                break;
            case 1:
                estadoAnimo = "Triste";
                break;
            case 2:
                estadoAnimo = "Enojado";
                break;
            case 3:
                estadoAnimo = "Preocupado";
                break;
        }
    }
    
    //activar la funcionalidad del boton para continuar
    void activarBotonContinuar()
    {
        botonContinuarButton.interactable = true;
    }
    //desactivar la funcionalidad del boton para continuar
    void desactivarBotonContinuar()
    {
        botonContinuarButton.interactable = false;
    }
    //cambiar a la siguiente pregunta
    public void siguientePregunta()
    {
        //cuando inicia el formulario de la pregunta 1 esta activo
        //ocultar la pregunta actual
        listaPreguntas[posicionPregunta].SetActive(false);
        //mostrar la siguiente pregunta
        posicionPregunta++;
        listaPreguntas[posicionPregunta].SetActive(true);
        desactivarBotonContinuar();
        if (posicionPregunta == 6)
        {
            btnContinuar.SetActive(false);
            btnFin.SetActive(true);
        }
        
    }
    //realizar una validacion sobre si ya se selecciono alguna de la dos opciones
    public void validarSeleccionGenero(int valor)
    {
        GameObject[] listaBotones = new GameObject[2];
        listaBotones = GameObject.FindGameObjectsWithTag("GameController");
        if (valor==0)
        {
            listaSombrasBotones[0].SetActive(false);
            listaSombrasBotones[1].SetActive(true);
            genero = "femenino";
        }
        else
        {
            listaSombrasBotones[1].SetActive(false);
            listaSombrasBotones[0].SetActive(true);
            genero = "masculino";
        }
        activarBotonContinuar();
    }
    //validacion y asignacion de un valor dependiendo si toma medicamentos o no
    public void validarMedicinas(int valor)
    {
        GameObject[] listaBotones = new GameObject[2];
        listaBotones = GameObject.FindGameObjectsWithTag("GameController");
        if (valor == 0)
        {
            listaSombrasBotones[2].SetActive(false);
            listaSombrasBotones[3].SetActive(true);
            medicamentos = true;
        }
        else
        {
            listaSombrasBotones[3].SetActive(false);
            listaSombrasBotones[2].SetActive(true);
            medicamentos = false;
        }
        activarBotonContinuar();
    }
    //validacion y asignacion de un valor dependiendo si fue al psicologo o no
    public void validarSeleccionPsicologo(int valor)
    {
        GameObject[] listaBotones = new GameObject[2];
        listaBotones = GameObject.FindGameObjectsWithTag("GameController");
        if (valor == 0)
        {
            listaSombrasBotones[4].SetActive(false);
            listaSombrasBotones[5].SetActive(true);
            psicologo = true;
        }
        else
        {
            listaSombrasBotones[5].SetActive(false);
            listaSombrasBotones[4].SetActive(true);
            psicologo = false;
        }
        activarBotonContinuar();
    }
    //valida que se haya escrito algo de texto
    public void validarTexto()
    {
        datoIngresadoTxt = GameObject.Find("txtResumen").GetComponent<Text>();
        nombreUsuario = datoIngresadoTxt.text;
        Button botonFin = btnFin.GetComponent<Button>();
        if (nombreUsuario.Length > 10)
        {
            botonFin.interactable = true;
        }
        else
        {
            botonFin.interactable = true;
        }
    }
    //funcion para presentar los resultados obtenidos de la encuesta

}