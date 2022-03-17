using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
   
    private Aviao aviao;
    private Pontuacao pontuacao;
    private AudioSource audioTrilhaSonora;
    private InterfaceGameOver interfaceGameOver;
    private GeradorDeObstaculos obstaculos;
    private ControleDeDificuldade tempodificuldade;
    private MaoPiscando maoPiscando;

    private void Awake()
    {
        this.audioTrilhaSonora = GetComponent<AudioSource>();
    }
    private void Start()
    {
        this.aviao = GameObject.FindObjectOfType<Aviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
        this.obstaculos = GameObject.FindObjectOfType<GeradorDeObstaculos>();
        this.tempodificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
        this.maoPiscando = GameObject.FindObjectOfType<MaoPiscando>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.audioTrilhaSonora.Stop();
        this.pontuacao.SalvarPontuacao();
        this.interfaceGameOver.MostrarInterface();
    }

    public void ReiniciarJogo()
    {
        
        this.DestruirObstaculos();
        this.obstaculos.NaoGeraObstaculos();
        this.aviao.Reiniciar();
        this.interfaceGameOver.EsconderInterface();
        this.obstaculos.ReiniciaCronometro();
        this.tempodificuldade.ReiniciaTempo();
        Time.timeScale = 1;
        this.pontuacao.ReiniciarPontos();
        this.maoPiscando.AparecerMaoPiscando();
        this.audioTrilhaSonora.Play();
    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }

    private void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
