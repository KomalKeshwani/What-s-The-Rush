using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator anim;

    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  Play_RunAnimation(int run)
    {
        anim.SetInteger(TagManager.RUN_ANIMATION_PARAMETER, run);

    }

    public void Play_JumpAnimation(bool jump)
    {
        anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, jump);
    }
}
