using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PointXp : MonoBehaviour
{

    private int exppoint = 0;
    private int lvl =0;
    //compteur kill variable
    [SerializeField] private TextMeshProUGUI xp;



    void Update()
    {
        xp.text = "point d'xp" + exppoint + "level :"+ lvl;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PasGentil"))
        {
            Destroy(other.gameObject);
            int v = exppoint + 10;
            exppoint = v;
         }

        if(exppoint == 30)
        {
            lvl = 1;
        }
        if (exppoint == 60)
        {
            lvl = 2;
        }




    }



}