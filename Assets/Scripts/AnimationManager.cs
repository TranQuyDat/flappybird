using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim_birdFly;
    public Rigidbody2D Rb_player;

    // Update is called once per frame
    void Update()
    {
        anim_birdFly.SetFloat("Velocity_y", Rb_player.velocity.y);
        
    }
    public void checkBirdDie(bool isdie)
    {
        anim_birdFly.SetBool("isdie", isdie);
    }
}
