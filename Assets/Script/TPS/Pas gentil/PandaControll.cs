using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaControll : MonoBehaviour
{
    private RaycastHit Hit;
    [SerializeField] private float speedy = 5f;
    //variable sound,anim,particule
    public AudioClip SpawnSoundmageule;
    public GameObject Particulespawn;
   
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(SpawnSoundmageule);
        Instantiate(Particulespawn, transform.position, Quaternion.identity);
        InvokeRepeating("speedboost", 30f, 30f);
        InvokeRepeating("Rotate", 15f, 15f);
    }

    // Update is called once per frame
    void Update() { 

        transform.Translate(Vector3.forward * speedy * Time.deltaTime);

        if(Physics.Raycast(transform.position,transform.TransformDirection( Vector3.forward),out Hit,4))
        {
            Rotate();
        }

    }
    private void Rotate()
    {
        transform.Rotate(Vector3.up * Random.Range(50, 200));
    }

    private void speedboost()
    {

        speedy += 20;

    }

}


