using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider volumeSliderMaster;
    [SerializeField] private Slider volumeSliderMusique;
    [SerializeField] private Slider volumeSliderSon;
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private AudioMixer audioMixer;

    private Resolution[] resolutions;
    private int currentResolutionID;

    private void Awake()
    {
        //Init Resolutions
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> _resolutionLabels = new List<string>();
        for (var i = 0; i < resolutions.Length; i++)
        {
            _resolutionLabels.Add(resolutions[i].width + "x" + resolutions[i].height);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currentResolutionID = i;
        }

        resolutionDropDown.AddOptions(_resolutionLabels);

        //Init les valeurs
        resolutionDropDown.value = currentResolutionID;
        fullscreenToggle.isOn = Screen.fullScreen;
        audioMixer.GetFloat("MasterVol", out float _volumeMaster);
        audioMixer.GetFloat("MusiqueVol", out float _volumeMusique);
        audioMixer.GetFloat("SonVol", out float _volumeSon);
        volumeSliderMaster.value = Mathf.InverseLerp(-80, 5f, _volumeMaster);
        volumeSliderMusique.value = Mathf.InverseLerp(-80, 5f, _volumeMusique);
        volumeSliderSon.value = Mathf.InverseLerp(-80, 5f, _volumeSon);

        //Link les events
        volumeSliderMaster.onValueChanged.AddListener(UpdateVolumeMaster);
        volumeSliderMusique.onValueChanged.AddListener(UpdateVolumeMusique);
        volumeSliderSon.onValueChanged.AddListener(UpdateVolumeSon);
        resolutionDropDown.onValueChanged.AddListener(UpdateResolution);
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscren);
    }

    private void UpdateVolumeMaster(float _value)
    {
        audioMixer.SetFloat("MasterVol", Mathf.Lerp(-80, 5f, _value));
        print("Audio Mixer : " + _value);
    }

        private void UpdateVolumeMusique(float _value)
    {
        audioMixer.SetFloat("MusiqueVol", Mathf.Lerp(-80, 5f, _value));
        print("Audio MixerMusique : " + _value);
    }

        private void UpdateVolumeSon(float _value)
    {
        audioMixer.SetFloat("SonVol", Mathf.Lerp(-80, 5f, _value));
        print("Audio MixerSon : " + _value);
    }

    private void UpdateResolution(int _value)
    {
        currentResolutionID = _value;
        Screen.SetResolution(resolutions[currentResolutionID].width, resolutions[currentResolutionID].height, Screen.fullScreen);
        print("Resolution : " + resolutions[currentResolutionID]);
    }

    private void ToggleFullscren(bool _value)
    {
        Screen.fullScreen = _value;
        print("Fullscreen : " + Screen.fullScreen);
    }
}