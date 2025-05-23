using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public Pedido pedidoActual;
    public float pacienciaMax = 10f;
    private float pacienciaActual;

    public Image barraPaciencia;
    public Image fotoCliente;
    public TextMeshProUGUI pedidoTxt;

    public bool atendido = false;

    public void inicializar(Pedido nuevoPedido)
    {
        pedidoActual = nuevoPedido;
        pacienciaActual = pacienciaMax;
        atendido = false;
        actualizarPedido();
    }

    private void Update()
    {
        if (atendido) return;

        pacienciaActual -= Time.deltaTime;
        barraPaciencia.fillAmount = pacienciaActual / pacienciaMax;
        if (pacienciaActual <= 0)
        {
            GameManager.instace.clienteSeFue(this);
        }
    }

    public void actualizarPedido()
    {
        string texto = "Sabores: " + string.Join(", ", pedidoActual.saboresEsperados.ConvertAll(s => s.nombre)) +
                        "\nCubiertas: " + string.Join(", ", pedidoActual.cubiertasEsperadas.ConvertAll(s => s.nombre)) +
                        "\nDecoración: " + (pedidoActual.decoracionEsperada != null ? pedidoActual.decoracionEsperada.nombre : "ninguna");
        pedidoTxt.text = texto;
    }

    public void serSeleccionado()
    {
        GameManager.instace.seleccionarCliente(this);
    }
}
