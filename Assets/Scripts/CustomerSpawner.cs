using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform spawnPoint;

    public float tiempoEntreClientes = 5f;
    private float tiempoRestante;

    public List<string> saboresDisponibles;

    private bool puedeSpawnear = true;

    private void Start()
    {
        tiempoRestante = tiempoEntreClientes;
        spawnNuevoCliente();
    }

    private void Update()
    {
        if (!puedeSpawnear) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            spawnNuevoCliente();
            tiempoRestante = tiempoEntreClientes;
        }
    }

    private void spawnNuevoCliente()
    {
        GameObject clienteGO = Instantiate(customerPrefab, spawnPoint.position,Quaternion.identity);
        Customer nuevoCliente = clienteGO.GetComponent<Customer>();

        Pedido nuevoPedido = generarPedidoAleatorio();
        nuevoCliente.pedidoActual = nuevoPedido;

        OrderManager.instance.EstablecerClienteActual(nuevoCliente);

    }

    private Pedido generarPedidoAleatorio()
    {
        Pedido pedido = new Pedido();
        pedido.sabores = new List<string>();

        int cantidadSabores = UnityEngine.Random.Range(1,3);

        List<string> copiaSabores = new List<string>(saboresDisponibles);

        for (int i = 0; i < cantidadSabores && copiaSabores.Count > 0; i++)
        {
            int index = UnityEngine.Random.Range(0, copiaSabores.Count);
            pedido.sabores.Add(copiaSabores[index]);
            copiaSabores.RemoveAt(index);
        }

        return pedido;
    }
}
