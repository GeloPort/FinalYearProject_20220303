using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    bool isAttack;
    bool enemyClose;
    bool canAttack;
    public Animator attackAnim;
    public AudioSource attackHit;
    public AudioSource attackMiss;
    public Slider staminaBar;
    public Text AttackText;

    //starts the scene by defining that the player can attack
    private void Start()
    {
        canAttack = true;
    }

    //Update is called once per frame
    void Update()
    {
        //Checks if the player can attack while he's pressing the left mouse button, defining the action as an "Attack" and checks if the enemy is close to the player
        //to define the attack as a Hit or a Miss, starting a coroutine that begins a cooldown where the player can't attack during its duration
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            if (enemyClose)
            {
                playerAttack();
                canAttack = false;
            }
            else
            {
                playerMiss();
                canAttack = false;
            }
            StartCoroutine("hasAttacked");
        }

        //Toggles on and off an element of the UI that motivates the player to attack, in order to let them know that they can attack or not
        if (canAttack)
        {
            AttackText.enabled = true;
        }
        else
        {
            AttackText.enabled = false;
        }
    }

    //A coroutine is a function that can suspend its execution (yield) until the given YieldInstruction finishes
    IEnumerator hasAttacked()
    {
        //Through a Linear Interpolation, controls a UI Slider for as long as the interpolation value (staminaCount) is lower than 1, which is the maximum value of a UI Slider
        float staminaCount = 0;
        while(staminaCount < 1){
            yield return null;
            staminaCount += 0.5f * Time.deltaTime;
            staminaBar.value = Mathf.Lerp(0, 1, staminaCount);

            //Once staminaCount is equal or bigger than 1, allows the player to attack again
            if (staminaCount >= 1)
            {
                canAttack = true;
            }
        }
    }

    //OnTriggerEnter happens on the FixedUpdate function when two GameObjects collide
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyClose = true;
        }
    }

    //OnTriggerExit is called when the Collider has stopped touching the trigger.
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyClose = false;
        }
    }

    //If the player hits the target (Attack is done with Target in collider), playerAttack plays an audio queue for the hit, the attack animation and sets the staminaBar slider value to 0
    void playerAttack()
    {
        attackHit.Play();
        attackAnim.Play("AttackAnim");
        staminaBar.value = 0;
    }

    //If the player misses the target (Attack is done with Target out of the collider), playerAttack plays an audio queue for the miss, the attack animation and sets the staminaBar slider value to 0
    void playerMiss()
    {
        attackMiss.Play();
        attackAnim.Play("AttackAnim");
        staminaBar.value = 0;
    }
}
