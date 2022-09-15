using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart
{
    Root,
    Head,
    Chest,
    LeftHand,
    RightHand,
    LeftFoot,
    RightFoot
}

public class CharacterParticles : MonoBehaviour
{
    public VisualFX footstepsFX;
    public VisualFX metalFootstepsFX;
    public PhysicMaterial metal;

    [Header("Body Parts")]
    public Transform leftFoot;
    public Transform rightFoot;
    public Transform leftHand;
    public Transform rightHand;
    public Transform head;
    public Transform chest;

    // private dictionary for quick access to transforms
    Dictionary<BodyPart, Transform> parts;
    public Transform GetBodyPart(BodyPart part)
    {
        // lazy initialisation - fill the Dictionary the first time we need it
        if (parts == null)
        {
            parts = new Dictionary<BodyPart, Transform>();
            parts[BodyPart.Root] = transform;
            parts[BodyPart.Head] = head;
            parts[BodyPart.Chest] = chest;
            parts[BodyPart.LeftHand] = leftHand;
            parts[BodyPart.RightHand] = rightHand;
            parts[BodyPart.LeftFoot] = leftFoot;
            parts[BodyPart.RightFoot] = rightFoot;
        }

        // quick look up with Dictionary
        if (parts.ContainsKey(part))
            return parts[part];

        return transform;
    }

    public void Step(int footIndex)
    {
        if (footIndex == 1)
            Debug.Log("left!");
        if (footIndex == 2)
            Debug.Log("right!");

        // find the correct foot to spawn the particles at
        Transform foot = footIndex == 1 ? leftFoot : rightFoot;

        // determine the material we're standing on
        PhysicMaterial ground = null;
        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position + Vector3.up, Vector3.down), out hit))
            ground = hit.collider.sharedMaterial;
        VisualFX fx = ground == metal ? metalFootstepsFX : footstepsFX;

        // instantiate the copy using our VisualFX system
        GameObject go = fx.Spawn(foot);

        // clean up the particle system in a few seconds, after all particles have died off
        Destroy(go, 5);
    }

    public void Spell(int spellIndex)
    {
        if (spellIndex == 1)
            Debug.Log("two hand spell");
        if (spellIndex == 2)
            Debug.Log("wide arm spell");
    }
}

