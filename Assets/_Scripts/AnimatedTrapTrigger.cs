using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTrapTrigger : MonoBehaviour {

    //reference to animation to unfreeze
    [SerializeField] private Animator anim;

	private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Object with collider entered trigger");
        if (anim) anim.enabled = true;

    }
    
}
