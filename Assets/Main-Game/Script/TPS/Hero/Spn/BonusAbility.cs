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
    public float bonusDuration = 5f;  // Durée du bonus en secondes

    private float cooldownTimer = 0f;  // Temps restant avant la prochaine activation du bonus

    private SpnMouvement playerMovement;  // Référence au script SpnMouvement

    private void Start()
    {
        playerMovement = GetComponent<SpnMouvement>();  // Récupérer la référence au script SpnMouvement attaché au même GameObject
    }

    public void ActivateBonus()
    {
        if (!bonusActive && cooldownTimer <= 0f)
        {
            // Activer le bonus
            bonusActive = true;
            cooldownTimer = cooldownTime;

            // Augmenter la vitesse du joueur pendant la durée du bonus
            playerMovement.speed = vmax;

            // Désactiver le bonus après la durée spécifiée
            Invoke("DeactivateBonus", bonusDuration);
            Debug.Log("bonus activer ");
            
        }
    }

    public void DeactivateBonus()
    {
        // Rétablir la vitesse normale du joueur
        playerMovement.speed = seepd_originel;

        bonusActive = false;
        Debug.Log("bonus fin ");
    }

    public void Update()
    {
        // Mettre à jour le temps restant avant la prochaine activation du bonus
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownTimer = Mathf.Clamp(cooldownTimer, 0f, cooldownTime);
        }

        // Vérifier si le temps de recharge est terminé
        if (cooldownTimer <= 0f)
        {
            bonusActive = false;
            
        }

        // Vérifier si la touche d'activation du bonus est enfoncée
        if (Input.GetKeyDown(activationKey))
        {
            ActivateBonus();
        }
    }
}