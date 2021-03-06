using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour
{
    [SerializeField]
    private Text valorRecorde;
    [SerializeField]
    private GameObject imagemGameOver;

    public void MostrarInterface()
    {
        this.AtualizarInterfaceGrafica();
        this.imagemGameOver.SetActive(true);
    }

    public void EsconderInterface()
    {
        this.imagemGameOver.SetActive(false);
    }
    private void AtualizarInterfaceGrafica()
    {
        int recorde = PlayerPrefs.GetInt("recorde");

        this.valorRecorde.text = recorde.ToString();

    }
}
