using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    [Tooltip("Key to press for this spell")]
    public KeyCode key;
    [Tooltip("Name of Trigger in Animation Controller")]
    public string animationTrigger;

    [Tooltip("castFX goes off on castPart as soon as the key is pressed")]
    public VisualFX castFX;
    public BodyPart castPart;

    [Tooltip("spellFX goes off on castPart as soon as the key is pressed")]
    public VisualFX spellFX;
    public BodyPart spellPart;

    public Animator animator;
    public CharacterParticles particles;
    public bool active = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && active == false)
        {
            // fire off the animation, and mark us as an active spell
            animator.SetTrigger(animationTrigger);
            active = true;
            // do the cast FX immediately
            if (castFX != null)
                castFX.Spawn(particles.GetBodyPart(castPart));
            active = false;
        }
    }
}

