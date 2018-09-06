using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    public AudioClip[] levelMusicArray;
    private AudioSource audioSource;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        AudioClip currentLevelMusic = levelMusicArray[scene.buildIndex];
        
        if(currentLevelMusic != null)
        {
            audioSource.clip = currentLevelMusic;
            /*  Error on 36. Due to audioSource.clip being null when it gets assigned? 
             *  working even with error. 
             *  NullReferenceException: Object reference not set to an instance of an object
                MusicPlayer.OnSceneLoaded (Scene scene, LoadSceneMode loadSceneMode) (at Assets/Scripts/MusicPlayer.cs:36)
                UnityEngine.SceneManagement.SceneManager.Internal_SceneLoaded (Scene scene, LoadSceneMode mode) 
                (at C:/buildslave/unity/build/artifacts/generated/common/runtime/SceneManagerBindings.gen.cs:245)
             * */
            audioSource.loop = true;
            audioSource.Play();
        }
    }
  
    public void SetVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }

}
