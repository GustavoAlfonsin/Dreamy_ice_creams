using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPasoUI : MonoBehaviour
{
    public PasoDePreparacion paso;
    public HeladoManager manager;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            paso.AplicarPaso(manager.heladoActual);
            manager.actualizarVista();
        });
    }
}
