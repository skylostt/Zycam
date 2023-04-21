using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button Serverbtn;
    [SerializeField] private Button Hostbtn;
    [SerializeField] private Button Clientbtn;
  
    private void Awake() {

        Serverbtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();
        });
        Hostbtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });
        Clientbtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });

    }


}
