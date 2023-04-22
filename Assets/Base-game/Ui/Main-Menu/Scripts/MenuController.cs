using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public enum PanelType
{
    None,
    Main,
    Option,
    Credits,
}

public class MenuController : MonoBehaviour
{
    //dico
    [Header("Panels")]
    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType, MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();
    //event
    [SerializeField] private EventSystem eventController;
    private GameManager manager;
    private MenuInputs inputs;



    //audio 

    [SerializeField] private AudioClip SoundButton;
    [SerializeField] private float volume = 1f;
    [SerializeField] private float maxDistance = 500f;

    private static AudioSource audioSource;

    [SerializeField] private static void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume = 1f, float maxDistance = 500f)
    {
        if (audioSource == null)
        {
            // Trouver l'objet audio dans la scène et obtenir l'AudioSource attaché
            audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        }

        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.maxDistance = maxDistance;

        audioSource.Play();
    }







    private void Start()
    {
        manager = GameManager.instance;
        inputs = GetComponent<MenuInputs>();

        foreach (var _panel in panelsList)
        {
            if (_panel)
            {
                panelsDict.Add(_panel.GetPanelType(), _panel);
                _panel.Init(this);
            }
        }

        OpenOnePanel(PanelType.Main, false);
    }



    //control button
    private void OpenOnePanel(PanelType _type, bool _animate)
    {
        foreach (var _panel in panelsList) _panel.ChangeState(_animate, false);

        if (_type != PanelType.None) panelsDict[_type].ChangeState(_animate, true);
    }

    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type, true);
        PlayClipAtPoint(SoundButton, transform.position, volume, maxDistance);

    }

    public void switchscene(string _sceneName)
    {
        manager.switchscene(_sceneName);
        PlayClipAtPoint(SoundButton, transform.position, volume, maxDistance);
    }


    public void Quit()
    {
        manager.Quit();
        PlayClipAtPoint(SoundButton, transform.position, volume, maxDistance);
    }

    public void SetSelectedGameObject(GameObject _element, Button _rightPanel, Button _leftPanel)
    {
        eventController.SetSelectedGameObject(_element);

        if (_rightPanel != null) inputs.SetShoulderListener(MenuInputs.Side.Right, _rightPanel.onClick.Invoke, _rightPanel.Select);
        if (_leftPanel != null) inputs.SetShoulderListener(MenuInputs.Side.Left, _leftPanel.onClick.Invoke, _leftPanel.Select);
    }




}