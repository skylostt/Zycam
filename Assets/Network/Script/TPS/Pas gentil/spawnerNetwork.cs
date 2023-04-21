using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class spawnerNetwork : MonoBehaviour
{
    //vairable GameObject
    public GameObject PandaRoux;
    //variable pool
    public List<GameObject> pasgentilpool;
    // dictionnaire sois disant plus opti mais ouais...
   // Dictionary<string, GameObject> pasgentilpool = new Dictionary<string, GameObject>();
    //file d'attente
   // Queue<GameObject> spawnQueue = new Queue<GameObject>();
    public int poolSize;
    int i;
    //Variable pos
    public Vector3 ZoneDeSpawnMin;
    public Vector3 ZoneDeSpawnMax;
    public Vector3 pos;
    //variable spawn
    public float tempsdespawn;
    public float premierspawn;



    void Start()
    {
        //on incrémente jusqu'au nombre choisit de spawn
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(PandaRoux);
            obj.GetComponent<NetworkObject>().Spawn();
           // obj.name = obj.name + i; //ajout d'un suffixe à chaque objet car mort sinon
            obj.SetActive(false);
          //  pasgentilpool.Add(obj.name, obj); // dans le dico avec nom comme clé (tu comprend le suffixe now x))
           // spawnQueue.Enqueue(obj);// on rajoute dans la fille d'attente
            pasgentilpool.Add(obj);

        }
        //spawn toute les xS
        InvokeRepeating ("SpawnPasGentil", premierspawn, tempsdespawn);
        
    }

    // on parcourt la liste pour trovuer les objets inutilisé
    GameObject GetPooledObject()
    {
        for (int i = 0; i < pasgentilpool.Count; i++)
        {
            if (!pasgentilpool[i].activeInHierarchy)
            {
                return pasgentilpool[i];
            }
        }
    return null;

    //récupérer l'objet au début de la file d'attente
   /* GameObject obj = spawnQueue.Dequeue();
    obj.SetActive(true);
    spawnQueue.Enqueue(obj); //remettre l'objet à la fin de la file d'attente
    return obj;*/
    }
    //le spawn
    void SpawnPasGentil()
    {
        GameObject obj = GetPooledObject();
        if (obj == null) return;
        //on vient def 3 random pour x y z à partir des vector 3 qu'on à définit dans le scipt
        float randomX = Random.Range(ZoneDeSpawnMin.x, ZoneDeSpawnMax.x);
        float randomY = Random.Range(ZoneDeSpawnMin.y, ZoneDeSpawnMax.y);
        float randomZ = Random.Range(ZoneDeSpawnMin.z, ZoneDeSpawnMax.z);
        //on l'applique
        obj.transform.position = new Vector3 (randomX, randomY, randomZ);
        pos = obj.transform.position;
        //pour la rotation
        obj.transform.rotation = Quaternion.identity;
        //important pour activer
        obj.SetActive(true);
        // dans le futur pour rajoute une anim au spawn
        // obj.GetComponent<Animator>().Play("spawnAnimation");
       

    }

}
