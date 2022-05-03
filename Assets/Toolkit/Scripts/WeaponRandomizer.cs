using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponRandomizer : MonoBehaviour
{
    
    public PlayerWeapon pWeapon;

    public BoxCollider bCol;
    public MeshRenderer mRend;

    public bool isActive = true;

    private void Update()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        isActive = false;
        StartCoroutine("sphereCooldown");
        pWeapon.weaponBlender();
        //flashEffect's alpha value goes to max and Mathf.Lerps back down to hide what happened. weaponBlender() might have to be run in last to make sure everything works
    }

    IEnumerator sphereCooldown()
    {
        Debug.Log("BlenderBall Off");
        yield return new WaitForSeconds(4);
        isActive = true;
    }
}