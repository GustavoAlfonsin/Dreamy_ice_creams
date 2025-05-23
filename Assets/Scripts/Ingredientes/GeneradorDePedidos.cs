using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GeneradorDePedidos : MonoBehaviour
{
    public List<SaborSO> saboresDisponibles;
    public List<CubiertaSO> cubiertasDisponibles;
    public List<DecoracionSO> decoracionesDisponibles;

    public Pedido GenerarPedidoAleatorio()
    {
        Pedido nuevo = new Pedido();
        nuevo.saboresEsperados = new List<SaborSO>();
        nuevo.cubiertasEsperadas = new List<CubiertaSO>();

        int cantSabores = UnityEngine.Random.Range(1,3);
        int cantCubiertas = UnityEngine.Random.Range(1,2);

        for (int i = 0; i < cantSabores; i++)
        {
            SaborSO s = saboresDisponibles[UnityEngine.Random.Range(0,saboresDisponibles.Count)];
            if (!nuevo.saboresEsperados.Contains(s))
            {
                nuevo.saboresEsperados.Add(s);
            }
        }

        for (int i = 0; i < cantCubiertas; i++)
        {
            CubiertaSO c = cubiertasDisponibles[UnityEngine.Random.Range(0, cubiertasDisponibles.Count)];
            if (!nuevo.cubiertasEsperadas.Contains(c))
            {
                nuevo.cubiertasEsperadas.Add(c);
            }
        }

        if (decoracionesDisponibles.Count > 0 && Random.value > 0.5f)
            nuevo.decoracionEsperada = decoracionesDisponibles[UnityEngine.Random.Range(0, decoracionesDisponibles.Count)];
        return nuevo;
    }
}
