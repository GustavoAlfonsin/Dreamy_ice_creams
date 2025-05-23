using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido 
{
    public List<string> sabores;


    public bool esCorrecto(List<string> seleccion)
    {
        if (seleccion.Count != sabores.Count)
        {
            return false;
        }

        foreach (string sabor in sabores)
        {
            if (!seleccion.Contains(sabor))
            {
                return false;
            }
        }
        return true;
    }
}
