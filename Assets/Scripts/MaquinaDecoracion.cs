using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDecoracion : PasoDePreparacion
{
    public DecoracionSO decoracion;
    public override void AplicarPaso(Helado helado)
    {
        helado.decoración = decoracion;
        Debug.Log("Agregada la decoración: " + decoracion.nombre);
    }
}
