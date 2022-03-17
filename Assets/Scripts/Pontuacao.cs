using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    private int pontos;
    [SerializeField]
    private Text textoPontuacao;
    private AudioSource audioPontuacao;
    [SerializeField]
    private GameObject pontuacao;

    private void Awake()
    {
        audioPontuacao = this.GetComponent<AudioSource>();
        EscondePontuacao();
    }
    public void AdicionarPontos()
    {
        this.pontos += 10;
        this.textoPontuacao.text = this.pontos.ToString();
        this.audioPontuacao.Play();
    }

    public void ReiniciarPontos()
    {
        this.pontos = 0;
        this.textoPontuacao.text = this.pontos.ToString(); 
    }

    public void SalvarPontuacao()
    {
        int recorde = PlayerPrefs.GetInt("recorde");

        if(this.pontos > recorde)
        {
            PlayerPrefs.SetInt("recorde", this.pontos);
        }
        
    }

    public void MostraPontuacao()
    {
        this.pontuacao.SetActive(true);
    }

    public void EscondePontuacao()
    {
        this.pontuacao.SetActive(false);
    }

}
