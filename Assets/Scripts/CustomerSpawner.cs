using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform[] spawnPoints;
    public List<Customer> clientesEnBarra = new List<Customer>();

    int maxClientes = 4;
    public GeneradorDePedidos generador;

    public void IntentarSpawnearCliente()
    {
        if (clientesEnBarra.Count >= maxClientes) return;

        GameObject nuevoObj = Instantiate(customerPrefab, spawnPoints[clientesEnBarra.Count]);
        Customer cliente = nuevoObj.GetComponent<Customer>();
        Pedido random = generador.GenerarPedidoAleatorio();
        cliente.inicializar(random);
        clientesEnBarra.Add(cliente);
    }

    public void quitarCliente(Customer cliente)
    {
        clientesEnBarra.Remove(cliente);
        Destroy(cliente.gameObject);
    }


    

    
}
