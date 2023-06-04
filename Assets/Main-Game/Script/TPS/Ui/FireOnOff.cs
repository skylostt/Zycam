using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireOnOff : MonoBehaviour
{
    [Header("FEUUU")]
    public GameObject firetnt;
    public GameObject firespn;
    public GameObject firetps;
    public GameObject firetce;
    [Header("Personalize + button")]
    public Button button; // référence au bouton dans l'éditeur
    public Color color1; // couleur 1
    public Color color2 = Color.red; // couleur 2
    private bool isColor1 = true; // bool pour la couleur
    [Header("Ref Perso")]
    [SerializeField] private Selector VerifPerso;

    public void Firestate()
    {
        if(VerifPerso.Verifperso == 1)
        {
        firetps.SetActive(!firetps.activeSelf);
        // alterne entre les deux couleurs
        if (isColor1)
        {
            button.image.color = color2;
        }
        else
        {
            button.image.color = color1;
        }
        isColor1 = !isColor1; // inverse la valeur du booléen
        }

        if(VerifPerso.Verifperso == 2)
        {
        firespn.SetActive(!firespn.activeSelf);
        // alterne entre les deux couleurs
        if (isColor1)
        {
            button.image.color = color2;
        }
        else
        {
            button.image.color = color1;
        }
        isColor1 = !isColor1; // inverse la valeur du booléen
        }

        if(VerifPerso.Verifperso == 3)
        {
        firetce.SetActive(!firetce.activeSelf);
        // alterne entre les deux couleurs
        if (isColor1)
        {
            button.image.color = color2;
        }
        else
        {
            button.image.color = color1;
        }
        isColor1 = !isColor1; // inverse la valeur du booléen
        }

        if(VerifPerso.Verifperso == 4)
        {
        firetnt.SetActive(!firetnt.activeSelf);
        // alterne entre les deux couleurs
        if (isColor1)
        {
            button.image.color = color2;
        }
        else
        {
            button.image.color = color1;
        }
        isColor1 = !isColor1; // inverse la valeur du booléen
        }




    }

}
