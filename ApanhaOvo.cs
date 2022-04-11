using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApanhaOvo : MonoBehaviour
{
    [SerializeField] Transform PontoOvos;
    Animator _animator;
    [SerializeField] float DelayApanhar = 0.5f;
    Collider apanhado;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ovo") && PontoOvos.GetComponentInChildren<Rigidbody>() == null && apanhado==null)
        {
            _animator.SetTrigger("apanhar");
            apanhado = other;
            other.tag = "Untagged";
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.isTrigger = true;
            Invoke("Apanhar", DelayApanhar);
        }
    }
    void Apanhar()
    {
        apanhado.transform.parent = PontoOvos;
        apanhado.transform.localPosition = Vector3.zero;
        apanhado.transform.GetComponent<Rigidbody>().isKinematic = true;
        apanhado = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
