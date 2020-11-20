using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legolas : MonoBehaviour
{
    float _charge;

    public float chargeMax;
    public float chargeRate;
    string fireButton = "Fire1";
    bool isDrawPlaying = false;
    private float thresholdCharge = 30;

    public float turningRate = 3600000f;


    private bool cooldown = false;
    private float cooldownTime = 1f;


    public Transform spawn;
    public Transform aimCamera;

    public Rigidbody arrowObj;
    private Animator anim;
    public Transform character;

     void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update(){
        if ( cooldown == false ) {
            Invoke("ResetCooldown", cooldownTime);
                 // cooldown = true;


            if(Input.GetButton(fireButton.ToString())){
                Debug.Log("DOWN");
                character.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0),  100f);

                if(!isDrawPlaying){
                    isDrawPlaying = true;
                    anim.SetTrigger("DrawBow");
                }

                if(_charge < chargeMax){
                  _charge += Time.deltaTime * chargeRate;
                }
                Debug.Log(_charge.ToString());
            }



            if(Input.GetButtonUp(fireButton.ToString())){
                Debug.Log(_charge.ToString());
                isDrawPlaying = false;
                if(_charge > thresholdCharge){
                    anim.Play("Archer_attack_recoil");
                    Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
                    arrow.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                    arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
                } else {
                    anim.Play("Archer_Idle");
                }

                _charge = 0;

                Debug.Log("UP");
            }
        }

    }

    void ResetCooldown(){
     cooldown = false;
    }
}
