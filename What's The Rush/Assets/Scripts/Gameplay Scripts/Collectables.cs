using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Door.instance.RegisterCollector(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag(TagManager.PLAYER_TAG))
        {
            //SoundController.instance.Play_CollectableSound();
            Door.instance.CollectorCollected();
            gameObject.SetActive(false);
        }
    }



}//class
