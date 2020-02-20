using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CharacterMovement characterMovement;
    BoxCollider2D attackCollider;
    [SerializeField] Slider manaSlider;
    
    [SerializeField] float hitCooldown = 0.3f;
    public int comboHit = 0;

    float currentComboTimer = 0f;
    float comboTimer = 1f;

    float decreaseTimer = 1f;
    float currentDecreaseTimer = 0f;


    [SerializeField] float manaRecievedPerPunch = 0.02f;
    [SerializeField] float manaLostPerTimerIteration = 0.05f;


    bool playerInCombo = false;
    bool canPlayerPunch = true;

    void Start()
    {
        attackCollider = this.transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S) && canPlayerPunch)
        {
            
            if(canPlayerPunch)
            {
                canPlayerPunch = false;
                ComboManager();
                
                Invoke("AvailePunching", hitCooldown);

            }
            
        }
        ManaManager();
        
    }

    private void ManaManager() //Mange timers for decreasing de mana of the player
    {
        if (currentComboTimer < comboTimer)
        {
            currentComboTimer += Time.deltaTime;
        }
        else
        {
            if (playerInCombo)
            {
                playerInCombo = false;
                comboHit = 0;
            }
            if (manaSlider.value > 0.01f) // si el mana ya es 0, que no haga nada
            {
                if (currentDecreaseTimer < decreaseTimer)
                {
                    currentDecreaseTimer += Time.deltaTime;
                }
                else
                {
                    currentDecreaseTimer = 0f;
                    manaSlider.value -= manaLostPerTimerIteration;
                }
            }
        }
    }
    //Idea de usar A para hacer combos contra enemigos o ataques especiales

    private void ComboManager()
    {
        if(!playerInCombo)
        {
            playerInCombo = true;
            currentDecreaseTimer = 0f;
            
        }
        currentComboTimer = 0;
        characterMovement.canPlayerMove = false;
        comboHit++;
        if(manaSlider.value < 0.99f) //Que lo haga mientras el mana sea menor que 99
        {
            manaSlider.value += manaRecievedPerPunch;
        }
        attackCollider.enabled = true;
        Invoke("RetreatPunch", 0.1f);
        switch (comboHit)
        {
            case 1:
                //animacion 1
                
                break;
            case 2:
                //animacion 2

                break;
            case 3:
                //animacion 3

                
                break;
        }
    }
        
    void RetreatPunch()
    {
        attackCollider.enabled = false;
    }

    private void AvailePunching()
    {
        canPlayerPunch = true;
        characterMovement.canPlayerMove = true;
        
    }
}
