using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legolas : MonoBehaviour
{
    float _charge;

    public float chargeMax;
    public float chargeRate;
    string fireButton = "Fire1";

    public Transform spawn;
    public Rigidbody arrowObj;

    void Update(){
        if(Input.GetButton(fireButton.ToString()) && _charge < chargeMax){
            Debug.Log("DOWN");

            _charge += Time.deltaTime * chargeRate;
            Debug.Log(_charge.ToString());
        }

        if(Input.GetButtonUp(fireButton.ToString())){
            Debug.Log(_charge.ToString());
            Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
            arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
            _charge = 0;
            Debug.Log("UP");
        }
    }
}
