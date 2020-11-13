﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth{get; private set;}
    public Stat damage;

    void Awake() {
      currentHealth = maxHealth;
    }

    void Update (){
      if(Input.GetKeyDown(KeyCode.T)){
        TakeDamage(10);
      }
    }

    public void TakeDamage(int damage){
      currentHealth -= damage;
      Debug.Log("Taken Damage " + damage);

      if(currentHealth <= 0){
        Die();
      }
    }

    public virtual void Die(){
      Debug.Log(transform.name + " DEAD");

      //* meant to be overridden
    }
}
