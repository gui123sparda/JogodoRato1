using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasesLiberadas : MonoBehaviour
{
    public GameObject[] botoes;
    public bool fase1=false;
    public bool fase2=false;
    public bool fase3=false;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fase1 = true;
        if (fase1==true) {
            botoes[0].SetActive(true);
            botoes[1].SetActive(false);
            botoes[2].SetActive(false);
            

        }
        if (fase2 == true)
        {
            
            
            botoes[1].SetActive(true);
            
        }
        if (fase3 == true) {
            
            
            botoes[2].SetActive(true);
        }
    }
}
