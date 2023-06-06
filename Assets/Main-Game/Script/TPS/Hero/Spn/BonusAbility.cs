using UnityEngine;

public class BonusAbility : MonoBehaviour
{
    public SpnMouvement SnMouvement;
    public KeyCode activationKey = KeyCode.B;  // Touche d'activation du bonus
    public float cooldownTime = 10f;  // Temps de recharge en secondes
    public float seepd_originel = 30;
    public float vmax = 80;
    public bool bonusActive = false;  // Indique si le bonus est actuellement actif

    public float bonusSpeedIncrease = 80;  // Augmentation de vitesse du bonus
    public float bonusDuration = 5f;  // Dur�e du bonus en secondes

    private float cooldownTimer = 0f;  // Temps restant avant la prochaine activation du bonus

    private SpnMouvement playerMovement;  // R�f�rence au script SpnMouvement

    private void Start()
    {
        playerMovement = GetComponent<SpnMouvement>();  // R�cup�rer la r�f�rence au script SpnMouvement attach� au m�me GameObject
    }

    public void ActivateBonus()
    {
        if (!bonusActive && cooldownTimer <= 0f)
        {
            // Activer le bonus
            bonusActive = true;
            cooldownTimer = cooldownTime;

            // Augmenter la vitesse du joueur pendant la dur�e du bonus
            playerMovement.speed = vmax;

            // D�sactiver le bonus apr�s la dur�e sp�cifi�e
            Invoke("DeactivateBonus", bonusDuration);
            Debug.Log("bonus activer ");
            
        }
    }

    public void DeactivateBonus()
    {
        // R�tablir la vitesse normale du joueur
        playerMovement.speed = seepd_originel;

        bonusActive = false;
        Debug.Log("bonus fin ");
    }

    public void Update()
    {
        // Mettre � jour le temps restant avant la prochaine activation du bonus
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownTimer = Mathf.Clamp(cooldownTimer, 0f, cooldownTime);
        }

        // V�rifier si le temps de recharge est termin�
        if (cooldownTimer <= 0f)
        {
            bonusActive = false;
            
        }

        // V�rifier si la touche d'activation du bonus est enfonc�e
        if (Input.GetKeyDown(activationKey))
        {
            ActivateBonus();
        }
    }
}