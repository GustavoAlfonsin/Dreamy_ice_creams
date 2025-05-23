using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helado 
{
    public List<SaborSO> sabores = new List<SaborSO>();
    public List<CubiertaSO> cubiertas = new List<CubiertaSO>();
    public DecoracionSO decoración;

    public void Reiniciar()
    {
        sabores.Clear();
        cubiertas.Clear();
        decoración = null;
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
        if (decoración != null) total += decoración.precio;

        return total;
    }

    public bool esIgualA(Pedido pedido)
    {
        return new HashSet<SaborSO>(sabores).SetEquals(pedido.saboresEsperados) &&
            new HashSet<CubiertaSO>(cubiertas).SetEquals(pedido.cubiertasEsperadas) &&
            decoración == pedido.decoracionEsperada;
    }
}
