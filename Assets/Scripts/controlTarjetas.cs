using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTarjetas : MonoBehaviour
{
    public GameObject[] tarjetas = new GameObject[20];
    void Start()
    {
        tarjetas = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < 19; i++)
        {
            tarjetas[i].SetActive(false);
            tarjetas[i].transform.position = new Vector3(-0.0311203f, 0.6852207f, 10f);
        }
        tarjetas[19].transform.position = new Vector3(-0.0311203f, 0.6852207f, 10f);
    }

    public void cambiarTarjeta()
    {
        GameObject tarjetaActual = GameObject.FindGameObjectWithTag("Player");
        tarjetaActual.SetActive(false);
        int indiceTarjeta = Random.Range(0, 19);
        tarjetas[indiceTarjeta].SetActive(true);
        tarjetas[indiceTarjeta].transform.position = new Vector3(-0.0311203f, 0.6852207f, 10f);
    }
}
