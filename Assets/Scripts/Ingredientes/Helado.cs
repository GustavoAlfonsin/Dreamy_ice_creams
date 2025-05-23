using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helado 
{
    public List<SaborSO> sabores = new List<SaborSO>();
    public List<CubiertaSO> cubiertas = new List<CubiertaSO>();
    public DecoracionSO decoraci�n;

    public void Reiniciar()
    {
        sabores.Clear();
        cubiertas.Clear();
        decoraci�n = null;
    }

    public int calcularPrecio()
    {
        int total = 0;
        foreach (var s in sabores)
        {
            total += s.precio;
        }
        foreach (var c in cubiertas)
        {
            total += c.precio;
        }
        if (decoraci�n != null) total += decoraci�n.precio;

        return total;
    }

    public bool esIgualA(Pedido pedido)
    {
        return new HashSet<SaborSO>(sabores).SetEquals(pedido.saboresEsperados) &&
            new HashSet<CubiertaSO>(cubiertas).SetEquals(pedido.cubiertasEsperadas) &&
            decoraci�n == pedido.decoracionEsperada;
    }
}
