using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;

    private List<string> ingredientesSeleccionados = new List<string>();
    private Customer clienteActual;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void seleccionarIngrediente(string nombre)
    {
        ingredientesSeleccionados.Add(nombre);
        UIManager.instance.ActualizarIngredientes(ingredientesSeleccionados);
    }

    public void entregarPedido()
    {
        if (clienteActual != null)
        {
            clienteActual.recibirPedido(ingredientesSeleccionados);
            limpiarPedido();
        }
    }

    private void limpiarPedido()
    {
        ingredientesSeleccionados.Clear();
        UIManager.instance.ActualizarIngredientes(ingredientesSeleccionados);
    }

    public void EstablecerClienteActual(Customer cliente)
    {
        clienteActual = cliente;
        UIManager.instance.MostrarPedido(clienteActual.pedidoActual.sabores);
    }
}
