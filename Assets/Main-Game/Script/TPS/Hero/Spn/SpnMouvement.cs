using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;
using UnityEngine.InputSystem;

public class SpnMouvement : MonoBehaviour
{
    //ref d'autre script
    [Header ("Boum boum les pandaroux")]
    [SerializeField] private Destruction KillboostAgent;

    //Mouvement déplacement+direction
    [Header("Mouvement/Cam")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    public float speed = 6f;

    [SerializeField] private float turnsmoothTime = 0.1f;
    float turnsmoothVelocity;

    //jump
    [Header("Jump/Gravité")]
    [SerializeField] private float jumpHeight = 3f;
    //gavité
    [SerializeField] private float gravity = -9.81f;
    
    //isgorundsecu
    [Header("Un sol ici je pense pas ")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    //input action escape et b manette pour retour par exemple
    private InputAction BackActions;
    [Header("Input")]
    [SerializeField] private OpenPanelButton OptionControl;
    [SerializeField] private OpenPanelButton CloseControl;
    [SerializeField] private MenuController UIControl;
    [SerializeField] private InputActionAsset actions;
    
    //private
    // on recup la velocity de x,y,z
    Vector3 velocity;
    //on créais la boolean isgrounded
    bool isGrounded;



    private void Awake()
    {
        BackActions = actions.FindActionMap("MenuNav").FindAction("back");
    }

    void Start() {
        // on fait dispawn la souris pour éviter de faire peur au éléphants
        Cursor.lockState = CursorLockMode.Locked;
        postProcessLayer.enabled = true;
        postProcessLayer.enabled = isPausedSpn;
        
    }

    //pour mettre en pause
    [Header("Prendre une pause sa fait du bien")]
    public GameObject pauseMenu;
    public bool isPausedSpn = false;

    // effect
    [Header("Hum le rtx version wish")]
    [SerializeField] private PostProcessLayer postProcessLayer;
    [SerializeField] private CinemachineFreeLook CameraMouvement;

    [Header("Ref Perso")]
    [SerializeField] private Selector VerifPerso;


    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = pauseMenu.activeSelf ? 0f : 1f; // Mettre en pause ou reprendre le temps
        CameraMouvement.enabled = !CameraMouvement.enabled;
        

        // Si le menu de pause est actif, on débloque la souris et on l'affiche
        if (pauseMenu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        // Sinon, on cache la souris et on la bloque pour la caméra
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    public void ResumeGameSpn()
    {
        if(VerifPerso.Verifperso == 2)
        {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CameraMouvement.enabled = true;
        postProcessLayer.enabled = false;
        isPausedSpn = !isPausedSpn;
        UIControl.isOptionOpen = false;
        Debug.Log("jesuisspn");
        }
       

    }
    // fin


    // Update is called once per frame
    private void Update()
    {

        //pause update
        if (Input.GetButtonDown("Pause"))
        {
            isPausedSpn = !isPausedSpn;
            postProcessLayer.enabled = isPausedSpn;
            TogglePauseMenu();
        }
        //Input back etc pause
        if (BackActions.triggered && !OptionControl.test)
        {        
            ResumeGameSpn();
            Debug.Log("ehe");
        }
        
        if(BackActions.triggered)
        {
            OptionControl.test = false;
        }

        if(CloseControl.verif)
        {
            OptionControl.test = false;
            CloseControl.verif = false;
        }

        // on vient dire que isgrounded contient la poisition du groundcheck définit dans l'éditor, la distance au sol qu'on sauhaite avoir, et le layer ground qui contient tous le terrain
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // pour bouger le personnage
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1f)
            {
                //MathF Atan2 doit theoriquement calculer l'angle par rapport à l'angle x (gauche droite) et z (haut bas)
                //théoriquement si on appuie sur z et d en même temps l'angle devrait être 90 ° à droite 0 était z normal
                // angle quand à lui permet de rendre le mouvement de rotation progressif
                //petite précision le fait d'utiliser Mathf.Rad2deg converti 90° en radian par exmple apparament c'est mieux pour unity
                //salut spn
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnsmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

            
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //Permet de bouger le perso par rapport à la direction * la vitesse * le temps qu'on appuie sur la touche
                controller.Move(moveDir * speed * Time.deltaTime);
            }
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //alors la comment dire... trop complex en soit c'est une formule réadapter en c# donc appart la connaitre par coeur mdr
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }



        //on vient prendre la velocity de l'axe y(haut bas) puis on fait + la valeur de la gravity qu'on multiplie chaque frame
        velocity.y += gravity * Time.deltaTime;
        // on prend la valeur move du character controler puis on vient prendre la velocity du vector 3 qu'on multiplie chaque frame
        controller.Move(velocity * Time.deltaTime);
        //tout ceci est basé sur une formule bien réelle mais srx je commence à avoir mal à la tête là
    }

    

} 
