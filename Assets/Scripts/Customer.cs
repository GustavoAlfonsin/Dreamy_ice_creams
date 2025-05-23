using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public Pedido pedidoActual;
    public float pacienciaMax = 10f;
    private float pacienciaActual;

    public Slider barraPaciencia;
    public Image fotoCliente;

    private bool esperando = true;

    private void Start()
    {
        pacienciaActual = pacienciaMax;
        StartCoroutine(Esperar());
    }

    IEnumerator Esperar()
    {
        while (pacienciaActual > 0 && esperando) 
        {
            pacienciaActual -= Time.deltaTime;
            barraPaciencia.value = pacienciaActual / pacienciaMax;
            yield return null;
        }

        if (esperando)
        {
            clienteSeVa(false);
        }
    }

    public void recibirPedido(List<string> sabores)
    {
        esperando = false;
        StopAllCoroutines();

        if (pedidoActual.esCorrecto(sabores))
        {
            GameManager.instace.agregarDinero(10);
            clienteSeVa(true);
        }
        else
        {
            clienteSeVa(false);
        }
    }

    private void clienteSeVa(bool feliz)
    {
        Destroy(this.gameObject,0.5f);
    }
}
