using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;
    [SerializeField]
    private GameObject objeto;
    public float cronometro;
    public float cronometroInicial;
    private ControleDeDificuldade controleDeDificuldade;
    private bool geracaoObstaculos;

    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
        this.cronometroInicial = this.tempoParaGerarFacil;
        NaoGeraObstaculos();
    }

    private void Start()
    {
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }

    // Update is called once per frame
    void Update()
    {
        this.cronometro -= Time.deltaTime;

        if(this.cronometro < 0 && this.geracaoObstaculos)
        {
            GameObject.Instantiate(this.objeto, this.transform.position, Quaternion.identity);
            this.cronometro = Mathf.Lerp(this.tempoParaGerarFacil,this.tempoParaGerarDificil, 
                this.controleDeDificuldade.Dificuldade);
        }
    }

    public void ReiniciaCronometro()
    {
        this.cronometro = this.cronometroInicial;
    }

    public void GeracaoObstaculos()
    {
        this.geracaoObstaculos = true;
    }

    public void NaoGeraObstaculos()
    {
        this.geracaoObstaculos = false;
    }
}
