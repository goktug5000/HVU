using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    public Vector3 anan;//YÜRÜME İŞLEMİNDE KULLANDIĞIM ŞEY
    public float H,velocity,motorRPM,liftF,thrust,maxThrust,timer4_250;
    public GameObject upRotor, lowRotor;
    public bool motorOn,timer250B;

    public Text hizimiz,rpmimiz,thrustimiz,himiz;

    void Start()
    {
        anan = transform.position;
        StartCoroutine(hiz_gösterici());

        motorRPM = 600;
        motorOn = false;
        liftF = motorRPM/120;

        thrust = (0.644f * 9.81f) / (0.0098f);
        maxThrust = 920;
    }

    // Update is called once per frame
    void Update()
    {
        H = this.transform.position.y;

        //liftF = motorRPM / 120;
        liftF = (thrust / 0.0098f);


        if (Input.GetKey(KeyCode.Space))
        {
            //transform.Translate(0, -0.1f, 0);
            //this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 100 * Time.deltaTime);
            //Debug.Log("motor çalışıyor");
            motorOn = true;
        }
        if (motorOn == true)
        {
            upRotor.transform.Rotate(0, -360 * motorRPM * Time.deltaTime / 60, 0, Space.Self);
            lowRotor.transform.Rotate(0, 360 * motorRPM * Time.deltaTime / 60, 0, Space.Self);

            this.gameObject.GetComponent<ConstantForce>().force = new Vector3(0, (thrust * 0.0098f), 0);

        }

        //Manual RPM
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            motorRPM += 20;
            thrust += 20;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            motorRPM -= 20;
            thrust -= 20;
        }
//250 yavaşlama
        if (H < 240 && velocity<0)
        {
            thrust = maxThrust;
            timer250B = true;
        }
        if (velocity >= 0)
        {
            timer250B = false;
            Debug.Log(timer4_250);
        }
        if (timer250B == true)
        {
            timer4_250 += Time.deltaTime*1;
        }


//saltu yazarsa otomatik RPM ayarı




        rpmimiz.text = motorRPM.ToString();
        thrustimiz.text = thrust.ToString();
        himiz.text = H.ToString();

        if (thrust >= 950)
        {
            thrust = 950;
        }
    }
    IEnumerator hiz_gösterici()
    {
        yield return new WaitForSeconds(0.1f);
//HIZ HESAPLAYICI
        try
        {
            velocity = (transform.position.y - anan.y)*10;
            anan = transform.position;
            //Debug.Log(anan);
            hizimiz.text = velocity.ToString();
            //Debug.Log(velocity.ToString());
        }
        catch
        {
            Debug.Log("hız yazmada sıkıntı");
        }

        StartCoroutine(hiz_gösterici());
    }
}


//CUMAYA GİTTİM GELCEM