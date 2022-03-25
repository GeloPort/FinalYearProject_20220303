using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public ToolGenerator TGen;
    public GameObject playerWeapon;
    public GameObject weaponHand;


    // Start is called before the first frame update
    void Start()
    {
        // Defines TGen as the DontDestroyOnLoadScene iteration, in order to not be confused with its prefab
        TGen = GameObject.FindGameObjectWithTag("ToolSpawner").GetComponent<ToolGenerator>();

        spawnPlayerWeapon();       
    }

    // Update is called once per frame
    void Update()
    {

    }

    // spawnPlayerWeapon is a script that enables the destruction of the weapon (in case it's modified or something similar) and sets it to the same settings as before
    public void spawnPlayerWeapon()
    {
        //checks if there's a weapon on scene and destroys it afterward
        if (playerWeapon != null)
        {
            Destroy(playerWeapon);
        }

        //instantiates the defined weapon model, relocates and resizes it, in order to fit in the player's hands
        playerWeapon = Instantiate(TGen.newWeapon, Vector3.up, weaponHand.transform.rotation, weaponHand.transform);
        playerWeapon.transform.position = weaponHand.transform.position;
        playerWeapon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }


    // weaponHeadBlender is a script that randomizes the player weapon's head component, by obtaining the int value of the array to which heads belong to, randomizing it and respawning it
    void weaponHeadBlender()
    {
        TGen.arrayPosHead = TGen.getRandomHead();
        TGen.createWeapon();
        spawnPlayerWeapon();
    }
}
