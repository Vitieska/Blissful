using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public List<AttackSO> combo;
    float lastClickedTime;
    float lastComboEnd;
    int comboCounter;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        {
            anim.runtimeAnimatorController = combo[comboCounter].animatorOV;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            attack();
        }
        ExitAttack();
    }

    void attack()
    {
        if(Time.time - lastComboEnd < 0.5f && comboCounter <= combo.Count)
        {
            CancelInvoke("EndCombo");

            if (Time.time - lastClickedTime >= 0.2f);
            anim.Play("Attack", 0, 0);
            comboCounter++;
            lastClickedTime = Time.time;

            if (comboCounter > combo.Count)
            {
                comboCounter = 0;
            }
        }
    }

    void ExitAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                 Invoke("EndCombo", 1);
            }
    }

    void EndCombo()
    {
        comboCounter = 0;
        lastComboEnd = Time.time;
    }
}
