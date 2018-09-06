using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private MusicPlayer musicManager;


	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("Start Menu");
    }

    public void SetDefults()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 2.0f;
    }
}
