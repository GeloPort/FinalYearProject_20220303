using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponRandomizer : MonoBehaviour
{
    
    public PlayerWeapon pWeapon;
    public BoxCollider bCol;
    public MeshRenderer mRend;
    public AudioSource anvilHit;
    public bool isActive = true;

    // Update is called once per frame
    private void Update()
    {
        //checks if the sphere "isActive", toggling its collider and mesh renderer active state
        if(isActive)
        {
            bCol.enabled = true;
            mRend.enabled = true;
        }
        else
        {
            bCol.enabled = false;
            mRend.enabled = false;
        }
    }

    //after triggering the sphere's collider, toggles the "isActive" bool, while starting its respawning coroutine, followed with
    //playing an audio queue and randomizing the current weapon in hand
    private void OnTriggerEnter(Collider other)
    {
        isActive = false;
        StartCoroutine("sphereCooldown");
        anvilHit.Play();
        pWeapon.weaponBlender();
    }

    //when the sphereCooldown coroutine is called, it waits 4 seconds and toggles the "isActive" bool
    IEnumerator sphereCooldown()
    {
        yield return new WaitForSeconds(4);
        isActive = true;
    }
}