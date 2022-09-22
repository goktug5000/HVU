using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject gorevYükü;
    bool birakmaB = false;
    float cd=1;


    // Start is called before the first frame update
    void Start()
    {
        gorevYükü.GetComponent<Rigidbody>().useGravity = false;
        //gorevYükü.SetActive(false);
    }

    void Update()
    {

        if (transform.position.y > 400 && birakmaB == false)
        {
            transform.Translate(0, -12 * Time.deltaTime, 0);
            //Debug.Log("12");
            gorevYükü.transform.position = this.gameObject.transform.position;
        }

        if (transform.position.y <= 400 || birakmaB==true)
        {
            dortyuz();
            transform.Translate(0, -6 * Time.deltaTime, 0);
            //Debug.Log("6");
            if (cd > 0)
            {
                cd -= Time.deltaTime * 1;
            }
            else
            {
                gorevYükü.GetComponent<Main>().motorOn = true;
            }
        }
        


//ERKEN BIRAKMA
        if (Input.GetKeyDown(KeyCode.P))
        {
            dortyuz();
            Debug.Log("erken bırakıldı");
        }

    }
    void dortyuz()
    {

        if (birakmaB == false)
        {
            Debug.Log("bırakıldı");
            //gorevYükü.SetActive(true);
            gorevYükü.transform.position = this.gameObject.transform.position;
            gorevYükü.GetComponent<Rigidbody>().useGravity = true;
            birakmaB = true;
        }
        
    }
}
