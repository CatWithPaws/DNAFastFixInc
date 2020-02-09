using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidioManager : MonoBehaviour
{

    public static AuidioManager instance;
    public AudioSource Game_Music_Source;
    public AudioSource Menu_Music_Source;
    public AudioSource SFX_Source;

    public AudioClip UI_Choose;
    public AudioClip MenuMusic;
    public AudioClip GameMusic;


    private AudioClip lastMus;
    private void Awake()
    {
        instance = this;
        
    }
    bool temp = true;
    private void Start()
    {
        
    }

    public void PlayMusic(GameObject menu,GameObject game) {

        if (menu.activeSelf)
        {
            Game_Music_Source.clip = MenuMusic;
        }
        else if(game.activeSelf)
        {
            Game_Music_Source.clip = GameMusic;
        }
        if (temp)
        {
            Game_Music_Source.Play();
            temp = false;
        }
        else if (lastMus != Game_Music_Source.clip)
        {
            Game_Music_Source.Play();
        }
        lastMus = Game_Music_Source.clip;
    }

    public void PlaySFX()
    {
        SFX_Source.PlayOneShot(UI_Choose);  
    }

}
