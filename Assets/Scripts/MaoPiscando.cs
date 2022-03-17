using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoPiscando : MonoBehaviour
{
    private SpriteRenderer imagem;
    [SerializeField]
    private GameObject logoInicial;

    private void Awake()
    {
        this.imagem = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            this.Desaparecer();
        }
    }

    private void Desaparecer()
    {
        this.imagem.enabled = false;
        this.logoInicial.SetActive(false);
    }

    public void AparecerMaoPiscando()
    {
        this.imagem.enabled = true;
        this.logoInicial.SetActive(true);
    }
}
