using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraVida : MonoBehaviour
{
    [SerializeField] public int Valor = 100;
    [SerializeField] float IntervaloTempo = 2;
    [SerializeField] bool DestroiQuandoTiraVida = true;
    float IntervaloAtual = 0;

    private void OnCollisionEnter(Collision collision)
    {
        ExecutaColisao(collision.gameObject);
    }
    private void OnCollisionStay(Collision collision)
    {
        ExecutaColisao(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        ExecutaColisao(other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        ExecutaColisao(other.gameObject);
    }
    public void ExecutaColisao(GameObject gameObject)
    {
        if (IntervaloAtual > 0) return;
        var vida=gameObject.GetComponent<Vida>();
        if (vida != null)
        {
            vida.TiraVida(Valor);
            IntervaloAtual = IntervaloTempo;
            if (DestroiQuandoTiraVida)
                Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (IntervaloAtual > 0)
            IntervaloAtual -= Time.deltaTime;
    }
}
