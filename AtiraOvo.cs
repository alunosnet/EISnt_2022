using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiraOvo : MonoBehaviour
{
    [SerializeField] Transform PontoOvo;
    [SerializeField] Transform PontoAtirar;
    [SerializeField] float forca;
    [SerializeField] float DelayAtirar = 0.5f;
    [SerializeField] float TempoVidaOvo = 5;
    [SerializeField] AudioClip SomAtirar;
    Rigidbody rbOvo;
    Animator _animator;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        if(Input.GetButtonDown("Fire1"))
        {
            rbOvo = PontoOvo.transform.GetComponentInChildren<Rigidbody>();
            if (rbOvo == null)
            {
                SistemaMensagens.instance.ShowMessage("Não tem ovo para atirar");
                
                return;
            }
            _animator.SetTrigger("atirar");
            Invoke("Atirar", DelayAtirar);
        }
    }
    void Atirar()
    {
        if (SomAtirar != null && _audioSource!=null)
        {
            _audioSource.clip= SomAtirar;
            _audioSource.loop= false;
            _audioSource.Play();
        }
        rbOvo.isKinematic = false;
        rbOvo.transform.parent = null;
        rbOvo.transform.position = PontoAtirar.position;
        rbOvo.transform.GetComponent<Collider>().isTrigger = false;
        var temp=rbOvo.gameObject.AddComponent<TiraVida>();
        temp.Valor = 50;
        rbOvo.AddForce(transform.forward * forca);
        Destroy(rbOvo.gameObject, TempoVidaOvo);
    }
}
