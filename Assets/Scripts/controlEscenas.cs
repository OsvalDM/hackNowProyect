using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlEscenas : MonoBehaviour
{
    public void comenzarPreguntas()
    {
        SceneManager.LoadScene("formularios");
    }
    public void verRecomendacioens()
    {
        SceneManager.LoadScene("recomendaciones");
    }
    public void volverMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}