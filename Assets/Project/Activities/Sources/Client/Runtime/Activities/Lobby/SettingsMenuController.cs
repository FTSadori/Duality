using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby
{
    public sealed class SettingsMenuController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private TMP_Dropdown fullscreenDropdown;
        [SerializeField] private TMP_Dropdown languageDropdown;
        [SerializeField] private Toggle vsyncToggle;
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider soundsVolumeSlider;

        List<Resolution> resolutions;
        List<string> fullscreenModes;

        private void Awake()
        {
            resolutions = Screen.resolutions.ToList();

            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(resolutions.ConvertAll(r => r.width.ToString() + "x" + r.height.ToString() + "@" + r.refreshRateRatio + "hz"));
            
            if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
                fullscreenDropdown.options.RemoveAll(o => o.text == "Exclusive fullscreen");
            if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Linux)
                fullscreenDropdown.options.RemoveAll(o => o.text == "Exclusive fullscreen" || o.text == "Maximized windows");
            fullscreenModes = fullscreenDropdown.options.ConvertAll(o => o.text);

            ReadFromPlayerPrefs();
            
            int currentResolutionIndex = resolutions.FindIndex(r => r.width == Screen.width && r.height == Screen.height && r.refreshRate == Screen.currentResolution.refreshRate);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();

            resolutionDropdown.onValueChanged.AddListener(ResolutionChanged);
            masterVolumeSlider.onValueChanged.AddListener(MasterVolumeChanged);
            musicVolumeSlider.onValueChanged.AddListener(MusicVolumeChanged);
            soundsVolumeSlider.onValueChanged.AddListener(SoundsVolumeChanged);
            vsyncToggle.onValueChanged.AddListener(VSyncValueChanged);
            fullscreenDropdown.onValueChanged.AddListener(FullscreenModeChanged);
        }

        public void ReadFromPlayerPrefs()
        {
            if (PlayerPrefs.HasKey("ResolutionIndex"))
            {
                ResolutionChanged(PlayerPrefs.GetInt("ResolutionIndex"));
                resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex");
                resolutionDropdown.RefreshShownValue();
            }
            if (PlayerPrefs.HasKey("FullscreenIndex"))
            {
                fullscreenDropdown.value = PlayerPrefs.GetInt("FullscreenIndex");
                fullscreenDropdown.RefreshShownValue();
            }
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                MasterVolumeChanged(PlayerPrefs.GetFloat("MasterVolume"));
                masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            }
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                MusicVolumeChanged(PlayerPrefs.GetFloat("MusicVolume"));
                musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            }
            if (PlayerPrefs.HasKey("SoundsVolume"))
            {
                SoundsVolumeChanged(PlayerPrefs.GetFloat("SoundsVolume"));
                soundsVolumeSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
            }
            if (PlayerPrefs.HasKey("VSync"))
            {
                vsyncToggle.isOn = PlayerPrefs.GetInt("VSync") > 0;
                VSyncValueChanged(PlayerPrefs.GetInt("VSync") > 0);
            }
        }

        public void ResolutionChanged(int resolutionIndex)
        {
            var resolution = resolutions[resolutionIndex];
            PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
        }

        public void FullscreenModeChanged(int fullscreenModeIndex)
        {
            string line = fullscreenModes[fullscreenModeIndex];
            PlayerPrefs.SetInt("FullscreenIndex", fullscreenModeIndex);
            if (line == "Windowed")
            {
                Screen.fullScreen = false;
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }
            else if (line == "Fullscreen window")
            {
                Screen.fullScreen = true;
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            }
            else if (line == "Exclusive fullscreen")
            {
                Screen.fullScreen = true;
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            }
            else
            {
                Screen.fullScreen = true;
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
            }
        }

        public void MasterVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("MasterVolume", volume);
            //
        }

        public void MusicVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("MusicVolume", volume);
            //
        }

        public void SoundsVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("SoundsVolume", volume);
            //
        }

        public void VSyncValueChanged(bool value)
        {
            PlayerPrefs.SetInt("VSync", value ? 1 : 0);
            QualitySettings.vSyncCount = value ? 1 : 0;
            //
        }

    }
}
