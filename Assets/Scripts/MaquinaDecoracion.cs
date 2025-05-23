using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDecoracion : PasoDePreparacion
{
    public DecoracionSO decoracion;
    public override void AplicarPaso(Helado helado)
    {
        helado.decoraci�n = decoracion;
        Debug.Log("Agregada la decoraci�n: " + decoracion.nombre);
    }
}
