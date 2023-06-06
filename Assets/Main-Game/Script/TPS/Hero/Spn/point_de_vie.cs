using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PointDeVie : MonoBehaviour
{

    private int pv = 100;
    //compteur kill variable
    [SerializeField] private TextMeshProUGUI BareVie;



    void Update()
    {
        BareVie.text = "pv: " + pv;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PasGentil"))
        {
            Destroy(other.gameObject);
            int v = pv - 10;
            pv = v;

        }




    }



}