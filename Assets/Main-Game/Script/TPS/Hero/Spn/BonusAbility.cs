using UnityEngine;

public class BonusAbility : MonoBehaviour
{
    public KeyCode activationKey = KeyCode.B;  // Touche d'activation du bonus
    public float cooldownTime = 10f;  // Temps de recharge en secondes
    public bool bonusActive = false;  // Indique si le bonus est actuellement actif

    private float cooldownTimer = 0f;  // Temps restant avant la prochaine activation du bonus

    // Fonction pour activer le bonus
    private void ActivateBonus()
    {
        if (!bonusActive && cooldownTimer <= 0f)
        {
            // Mettez ici le code pour activer votre bonus
            Debug.Log("Bonus activé !");

            bonusActive = true;
            cooldownTimer = cooldownTime;
        }
    }

    private void Update()
    {
        // Mettez à jour le temps restant avant la prochaine activation du bonus
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownTimer = Mathf.Clamp(cooldownTimer, 0f, cooldownTime);
        }

        // Vérifiez si le temps de recharge est terminé
        if (cooldownTimer <= 0f)
        {
            bonusActive = false;
            Debug.Log("bonus pret");
        }

        // Vérifiez si la touche d'activation du bonus est enfoncée
        if (Input.GetKeyDown(activationKey))
        {
            ActivateBonus();
        }
    }
}