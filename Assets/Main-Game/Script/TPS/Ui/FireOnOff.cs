using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireOnOff : MonoBehaviour
{
    public GameObject fire;
    public Button button; // référence au bouton dans l'éditeur
    public Color color1; // couleur 1
    public Color color2 = Color.red; // couleur 2
    private bool isColor1 = true; // bool pour la couleur


    public void Firestate()
    {
            fire.SetActive(!fire.activeSelf);



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
