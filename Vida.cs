using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] int vida = 100;
    [SerializeField] AudioClip SomPerdeVida;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Text TextVida;

   // AudioClip _somAnterior;

    void AtualizaUI()
    {
        if(TextVida!=null)
            TextVida.text = vida.ToString();
    }

    public int GetVida()
    {
        return vida;
    }
    public void TiraVida(int valor)
    {
        vida -= valor;
        if(vida<=0)
            Destroy(gameObject);
        else
        {
            if (_audioSource != null && SomPerdeVida != null)
            {
                //_somAnterior = _audioSource.clip;
                _audioSource.clip = SomPerdeVida;
                _audioSource.loop = false;
                _audioSource.Play();
                //Invoke("MudarSom", _audioSource.clip.length);
            }
            AtualizaUI();
        }
    }
    //void MudarSom()
    //{
    //    if (_somAnterior != null)
    //    {
    //        _audioSource.clip = _somAnterior;
    //        _audioSource.loop = true;
    //        _audioSource.Play();
    //    }
    //}
    public void GanhaVida(int valor)
    {
        vida += valor;
        if (vida > 100) vida = 100;
        AtualizaUI();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(_audioSource==null)
            _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.Log("Falta o componente audio source " + gameObject.name);
        AtualizaUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
