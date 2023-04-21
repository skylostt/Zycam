using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerSpawn : MonoBehaviour
{

    [SerializeField] private GameObject Spawner;

    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        GameObject Clone = Instantiate(Spawner, Vector3.zero,Quaternion.identity);
    }

}
