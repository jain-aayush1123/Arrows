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


    private bool cooldown = false;
    private float cooldownTime = 1f;


    public Transform spawn;
    public Transform aimCamera;

    public Rigidbody arrowObj;
    private Animator anim;
    private Transform myTransform;

     void Start()
    {
        anim = GetComponent<Animator>();
        myTransform  = GetComponent<Transform>();
    }

    void Update(){
        if ( cooldown == false ) {
            Invoke("ResetCooldown", cooldownTime);
                 // cooldown = true;

            myTransform.forward = aimCamera.forward;

            if(Input.GetButton(fireButton.ToString()) && _charge < chargeMax){
                Debug.Log("DOWN");

                _charge += Time.deltaTime * chargeRate;
                if(!isDrawPlaying){
                    isDrawPlaying = true;
                anim.SetTrigger("DrawBow");

                }
                Debug.Log(_charge.ToString());
            }



            if(Input.GetButtonUp(fireButton.ToString())){
                Debug.Log(_charge.ToString());
                isDrawPlaying = false;
                if(_charge > thresholdCharge){
                    anim.Play("Archer_attack_recoil");
                    Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
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
