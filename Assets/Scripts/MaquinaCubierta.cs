using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaCubierta : PasoDePreparacion
{
    public CubiertaSO cubierta;
    public override void AplicarPaso(Helado helado)
    {
        helado.cubiertas.Add(cubierta);
        Debug.Log("Agregada la cubierta: " + cubierta.nombre);
    }
}
