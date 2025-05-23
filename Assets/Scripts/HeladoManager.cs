using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class HeladoManager : MonoBehaviour
{
    public Helado heladoActual = new Helado();
    public Customer clienteActual;
    public TextMeshProUGUI estadoTxt;

    public void actualizarVista()
    {
        string texto = "Sabores: " + string.Join(", ", heladoActual.sabores.ConvertAll(s => s.nombre)) +
                        "\nCubiertas: " + string.Join(", ", heladoActual.cubiertas.ConvertAll(s => s.nombre)) +
                        "\nDecoración: " + (heladoActual.decoración != null ? heladoActual.decoración.nombre : "ninguna");
        estadoTxt.text = texto;
    }

    public void reiniciarHelado()
    {
        heladoActual.Reiniciar();
        actualizarVista();
    }

    public void entregarHeladoAlCliente()
    {
        if (clienteActual != null && heladoActual != null)
        {
            GameManager.instace.entregarPedido(clienteActual);
        }
    }

    public void seleccionarCliente(Customer cliente)
    {
        clienteActual = cliente;
    }


}
