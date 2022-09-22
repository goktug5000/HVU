using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cams : MonoBehaviour
{
    public GameObject MelekCamKoruyucuu, MelekCamGorevv, Cam;
    void Start()
    {
        MelekCamKoruyucuu.SetActive(true);
        MelekCamGorevv.SetActive(false);
        Cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MelekCamKoruyucuu.SetActive(true);
            MelekCamGorevv.SetActive(false);
            Cam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MelekCamKoruyucuu.SetActive(false);
            MelekCamGorevv.SetActive(true);
            Cam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MelekCamKoruyucuu.SetActive(false);
            MelekCamGorevv.SetActive(false);
            Cam.SetActive(true);
        }
    }
}
