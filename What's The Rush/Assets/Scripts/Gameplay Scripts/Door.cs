using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public static Door instance;

    private BoxCollider2D boxCol2D;

    private Animator anim;

    private int collectorCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        boxCol2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

   


    void OpenDoor()
    {
        anim.Play(TagManager.OPEN_ANIMATION_NAME);
    }

    void RemoveCollider()
    {
        boxCol2D.enabled = false;
    }


    public void RegisterCollector()
    {
        collectorCount++;
       
    }

    public void CollectorCollected()
    {
        collectorCount--;
        
        if(collectorCount ==0)
        {
            OpenDoor();
        }
    }










}//class




















