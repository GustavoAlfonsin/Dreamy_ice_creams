using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;

    public int dinero = 0;
    public int diaActual = 1;
    public int clientesAtendidos = 0;

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

    public void agregarDinero(int cantidad)
    {
        dinero += cantidad;
        UIManager.instance.actualizarDinero(dinero);
    }

    public void clienteAtendido()
    {
        clientesAtendidos++;
    }

    public void IniciarDia()
    {
        clientesAtendidos = 0;
    }

    public void finalizarDia()
    {

    }
}
