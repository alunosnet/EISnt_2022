using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOvo : MonoBehaviour
{
    [SerializeField] GameObject ModeloOvo;
    [SerializeField] GameObject ModeloOvoExplosivo;
    [SerializeField] float Intervalo = 2;
    [SerializeField] int NrOvos = 5;
    [SerializeField] Transform PosicaoOvo;
    float _IntervaloAtual;
    // Start is called before the first frame update
    void Start()
    {
        _IntervaloAtual = Intervalo;
        if (ModeloOvo == null)
            Debug.Log("Falta o prefab do ovo");
    }

    // Update is called once per frame
    void Update()
    {
        if(NrOvos > 0 && _IntervaloAtual>0)
        {
            _IntervaloAtual -= Time.deltaTime;
            if (_IntervaloAtual < 0)
            {
                if (NrOvos == 1)
                {
                    Instantiate(ModeloOvoExplosivo, PosicaoOvo.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(ModeloOvo, PosicaoOvo.position, Quaternion.identity);
                }
                NrOvos--;
                _IntervaloAtual = Intervalo;
            }
        }
    }
}
