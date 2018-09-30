using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    Rigidbody physic;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vector3;
    public float characterSpeed;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float aim;
    public float fireDelayTime;
    float fireTime = 0;
    public GameObject bullet;
    public Transform bulletExit;
    AudioSource bulletVoice;

	void Start () {
        physic = GetComponent<Rigidbody>();
        bulletVoice = GetComponent<AudioSource>();
		
	}

    void Update(){

        if(Input.GetButton("Fire1") && Time.time > fireTime) {
            fireTime = Time.time + fireDelayTime;
            Instantiate(bullet, bulletExit.position, Quaternion.identity);
            bulletVoice.Play();
        }

    }
	
	void FixedUpdate () {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vector3 = new Vector3(horizontal, 0, vertical);

        physic.velocity = vector3 * characterSpeed;

        physic.position = new Vector3(
            Mathf.Clamp(physic.position.x, minX, maxX),
            0.0f,
            Mathf.Clamp(physic.position.z, minZ, maxZ)
        );

        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * -aim);
	}
}
