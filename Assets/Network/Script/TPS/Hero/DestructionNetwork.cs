using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class DestructionNetwork : MonoBehaviour {
    //Ref au script de déplacement
    [SerializeField] private MouvementPour3personneNetwork Déplacement;
    //variable basic
    private int kill = 0;
    //compteur kill variable
    [SerializeField] private TextMeshProUGUI killcount;
    //variable vfx
    [SerializeField] private GameObject ChairVFX;
    [SerializeField] private GameObject SangVFX;
    //variable changer les stats avec le nb kill
    [SerializeField] private int PersoSpeedKill;
    //audio variable 
    [SerializeField] private AudioSource DestroySound;



    [ServerRpc]
    void UpdateKillCountServerRpc(int newKillCount)
    {
        kill = newKillCount;
        killcount.text = "kill : " + kill;
    }

    [ClientRpc]
    void RpcUpdateKillCount(int newKillCount)
    {
        kill = newKillCount;
        killcount.text = "kill : " + kill;
    }

    private void OnTriggerEnter(Collider other) {
   
    if (other.gameObject.CompareTag("PasGentil"))
        {
        Destroy(other.gameObject);
        kill++;
        UpdateKillCountServerRpc(kill);
        RpcUpdateKillCount(kill);
        Déplacement.speed += PersoSpeedKill;
        DestroySound.Play();
        Instantiate(ChairVFX, other.transform.position, Quaternion.identity);
        Instantiate(SangVFX, other.transform.position, Quaternion.identity);

        }
        

       
    
}



}