using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxControl : MonoBehaviour {

    public int fxSpeed;


    Rigidbody physic;
	void Start () {

        physic = GetComponent<Rigidbody>();
        physic.velocity = transform.forward * fxSpeed;
		
	}

}
