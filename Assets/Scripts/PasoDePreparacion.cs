using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PasoDePreparacion : MonoBehaviour
{
    public string nombrePaso;
    public abstract void AplicarPaso(Helado helado);
}
