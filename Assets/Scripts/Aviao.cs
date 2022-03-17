using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{
    private Rigidbody2D fisica;
    [SerializeField]
    private float forca;
    private Diretor diretor;
    private Vector3 posicaoInicial;
    private bool deveImpulsionar;
    private Animator animacao;
    private GeradorDeObstaculos geracaoObstaculos;
    private Pontuacao pontuacao;

    // Start is called before the first frame update
    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
        this.posicaoInicial = this.transform.position;
        this.animacao = this.GetComponent<Animator>();
        this.fisica.simulated = false;
    }

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<Diretor>();
        this.geracaoObstaculos = GameObject.FindObjectOfType<GeradorDeObstaculos>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            this.deveImpulsionar = true;
            this.fisica.simulated = true;
            this.pontuacao.MostraPontuacao();
            this.geracaoObstaculos.GeracaoObstaculos();
        }
        
    }

    private void FixedUpdate()
    {
        if(this.deveImpulsionar)
        {
            this.Impulsionar();
        }
        if(this.fisica.simulated)
        {
            this.animacao.SetFloat("VelocidadeY", this.fisica.velocity.y);
        }
        
    }

    public void Reiniciar()
    {
        this.fisica.simulated = false;
        this.transform.position = this.posicaoInicial;
        this.animacao.SetFloat("VelocidadeY", 0);
    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
        this.deveImpulsionar = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.fisica.simulated = false;
        this.diretor.FinalizarJogo();
    }
}
