using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour
{
    [SerializeField]
    private VariavelCompartilhadaFloat velocidade;

    private Vector3 posicaoInicial;

    private float tamandoRealDaImagem;
    private float tamanhoDaImagem;
    private float escala;

    private float deslocamento;

    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        this.tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x;
        this.escala = this.transform.localScale.x;
        this.tamandoRealDaImagem = tamanhoDaImagem * escala;
    }

    // Update is called once per frame
    void Update()
    {
        this.deslocamento = Mathf.Repeat(this.velocidade.valor * Time.time, this.tamandoRealDaImagem);
        this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
    }
}
