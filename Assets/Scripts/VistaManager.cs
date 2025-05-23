using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaManager : MonoBehaviour
{
    [Header("Paneles de vistas")]
    public GameObject panelFront;
    public GameObject panelBack;

    private bool enVistaFrontal = false;

    private void Start()
    {
        AlternarVista();
    }

    public void activarVistaFrontal()
    {
        panelFront.SetActive(true);
        panelBack.SetActive(false);
        enVistaFrontal = true;
    }

    public void activarVistaTrasera()
    {
        panelFront.SetActive(false);
        panelBack.SetActive(true);
        enVistaFrontal = false;
    }

    public void AlternarVista()
    {
        if (enVistaFrontal)
        {
            activarVistaTrasera();
        }
        else
        {
            activarVistaFrontal();
        }
    }
}
