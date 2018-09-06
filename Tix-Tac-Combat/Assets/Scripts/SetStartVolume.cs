using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicPlayer mp;
    
	void Start () {
        mp = FindObjectOfType<MusicPlayer>();
        if (mp)
        {
            mp.SetVolume(PlayerPrefsManager.GetMasterVolume());
        }
        else
        {
            Debug.LogWarning("No Music Player found");
        }
	}
}
