using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] float VelocidadeAndar = 5;
    [SerializeField] float VelocidadeRodar = 5;
    [SerializeField] float VelocidadeSalto = -2;
    CharacterController _characterController;
    Animator _animator;
    Vector3 velocidade;
    // Start is called before the first frame update
    void Start()
    {
        _characterController= GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("O player necessita de ter o componente character controller");
        _characterController.minMoveDistance = 0;
        if (VelocidadeSalto > 0)
            Debug.Log("A velocidade do salto deve ser negativa");
        _animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rodar
        float rodar = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up * rodar * VelocidadeRodar * Time.deltaTime);
        //andar
        float andar = Input.GetAxis("Vertical");

        if (andar > 0)
            andar *= Input.GetButton("Run") == true ? 2 : 1;

        Vector3 movimento = transform.forward * andar * VelocidadeAndar * Time.deltaTime;
        _characterController.Move(movimento);
        

        if (_animator != null)
            _animator.SetFloat("velocidade", andar);

        //gravidade
        if (Input.GetButtonDown("Jump"))
        {
            velocidade.y = Mathf.Sqrt(VelocidadeSalto * Physics.gravity.y);
            _animator?.SetTrigger("saltar");
        }
        velocidade += Physics.gravity * Time.deltaTime;
        _characterController.Move(velocidade*Time.deltaTime);
    }
}
