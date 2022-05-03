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

    private void Start()
    {
        canAttack = true;
    }
    //Update is called once per frame
    void Update()
    {
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

        if (canAttack)
        {
            AttackText.enabled = true;
        }
        else
        {
            AttackText.enabled = false;
        }
    }
    IEnumerator hasAttacked()
    {
        float staminaCount = 0;
        while(staminaCount < 1){
            yield return null;
            staminaCount += 0.5f * Time.deltaTime;
            staminaBar.value = Mathf.Lerp(0, 1, staminaCount);

            if (staminaCount >= 1)
            {
                canAttack = true;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyClose = false;
        }
    }


    void playerAttack()
    {
        attackHit.Play();
        attackAnim.Play("AttackAnim");
        staminaBar.value = 0;
    }

    void playerMiss()
    {
        attackMiss.Play();
        attackAnim.Play("AttackAnim");
        staminaBar.value = 0;
    }
}
