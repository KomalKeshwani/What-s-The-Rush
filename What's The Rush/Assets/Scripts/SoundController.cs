using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController instance;

    [SerializeField]
    private AudioSource playerJumpSound, gameOverSound, collectableSound, coldDrinkSound;

    

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Play_PlayerJumpSound()
    {
        // AudioSource.PlayClipAtPoint(playerJumpSound, transform.position);
        playerJumpSound.Play();
    }

    public void Play_GameOverSound()
    {
        //AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
        gameOverSound.Play();
    }

    public void Play_ColdDrinkAttackSound()
    {
        //AudioSource.PlayClipAtPoint(coldDrinkSound, transform.position);
        coldDrinkSound.Play();
    }

    public void Play_CollectableSound()
    {
        //AudioSource.PlayClipAtPoint(collectableSound, transform.position);
        collectableSound.Play();
    }











}//class














