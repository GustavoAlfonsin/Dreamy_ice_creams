using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI dineroTxt;
    public TextMeshProUGUI ingredientesTxt;
    public TextMeshProUGUI pedidoTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void actualizarDinero(int cantidad)
    {
        dineroTxt.text = "Dinero: $" + cantidad.ToString();
    }

    public void ActualizarIngredientes(List<string> ingredientes)
    {
        ingredientesTxt.text = "Seleccionado: " + string.Join(", ", ingredientes);
    }

    public void MostrarPedido(List<string> sabores)
    {
        pedidoTxt.text = "Pedido: " + string.Join (", ", sabores);
    }
}
