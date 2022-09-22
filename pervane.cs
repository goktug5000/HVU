using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pervane : MonoBehaviour
{
    public Main mainScr;
    public GameObject acik, kapali;
    void Start()
    {
        mainScr = GameObject.Find("GorevYuku").GetComponent<Main>();
        try
        {
            acik.SetActive(false);
            kapali.SetActive(true);
        }
        catch
        {
            Debug.Log("pervaneler açılıp kapanmadı");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainScr.motorOn == true)
        {
            acik.SetActive(true);
            kapali.SetActive(false);
        }
    }
}
