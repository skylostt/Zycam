using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestructionTps : MonoBehaviour 
{
    //Ref au script de déplacement
     [Header("Mouvement ref perso")]
    [SerializeField] private TpsMouvement DéplacementTps;
    //variable basic
    private int kill = 0;
    //compteur kill variable
     [Header("Compteur allo met toi à jour")]
    [SerializeField] private TextMeshProUGUI killcount;
    //variable vfx
    [Header("Vfx eh on a du budget")]
    [SerializeField] private GameObject ChairVFX;
    [SerializeField] private GameObject SangVFX;
    //variable changer les stats avec le nb kill
     [Header("Stats/kill")]
    [SerializeField] private int PersoSpeedKillTps;
    //audio variable 
     [Header("Audio")]
    [SerializeField] private AudioSource DestroySound;

    
    void Update()
    {
        killcount.text = "kill : " + kill;
    } 
    private void OnTriggerEnter(Collider other) {
   
    if (other.gameObject.CompareTag("PasGentil"))
        {
        Destroy(other.gameObject);
        kill++;
        DéplacementTps.speed += PersoSpeedKillTps;
        DestroySound.Play();
        Instantiate(ChairVFX, other.transform.position, Quaternion.identity);
        Instantiate(SangVFX, other.transform.position, Quaternion.identity);       
        }
    

       
    
}



}