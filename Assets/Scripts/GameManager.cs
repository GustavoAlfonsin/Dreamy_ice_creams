using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public HeladoManager heladoManager;
    public CustomerSpawner customerSpw;
    public TextMeshProUGUI dineroTxt;
    public int dinero = 0;
    public GameObject botonEntregar;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        actualizarDinero();
        InvokeRepeating("SpawnearCliente", 2f, 5f);
        botonEntregar.SetActive(false);
    }

    private void SpawnearCliente()
    {
        customerSpw.IntentarSpawnearCliente();
    }

    public void entregarPedido(Customer cliente)
    {
        if (cliente.pedidoActual == null) return;

        if (heladoManager.heladoActual.esIgualA(cliente.pedidoActual)) 
        {
            int ganancia = heladoManager.heladoActual.calcularPrecio();
            dinero += ganancia;
            cliente.atendido = true;
            customerSpw.quitarCliente(cliente);
            heladoManager.reiniciarHelado();
            actualizarDinero();
        }
        else
        {
            dinero -= 5;
            actualizarDinero();
        }
    }

    public void clienteSeFue(Customer cliente)
    {
        customerSpw.quitarCliente(cliente);
        dinero -= 5;
        actualizarDinero();
    }

    private void actualizarDinero()
    {
        dineroTxt.text = "$" + dinero;
    }

    public void seleccionarCliente(Customer cliente)
    {
        heladoManager.seleccionarCliente(cliente);
        botonEntregar.SetActive(true);
    }
}
