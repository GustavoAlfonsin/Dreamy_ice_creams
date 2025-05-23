using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaSabor : PasoDePreparacion
{
    public SaborSO sabor;
    public override void AplicarPaso(Helado helado)
    {
        helado.sabores.Add(sabor);
        Debug.Log("Agregado sabor: " + sabor.nombre);
    }
}
