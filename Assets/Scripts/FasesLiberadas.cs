using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FasesLiberadas : MonoBehaviour
{
    
    
    public bool fase1=false;
    public bool fase2=false;
    public bool fase3=false;
    
    public static FasesLiberadas fases;
    private void Awake()
    {

        
        if (fases == null)
        {
            fases = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (this!=fases)
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        if (this == fases) // If a duplicate object is destroyed, it does not free the first instance created.
            fases = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
