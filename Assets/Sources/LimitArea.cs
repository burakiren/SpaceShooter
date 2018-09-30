using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitArea : MonoBehaviour {

    void onTriggerExit (Collider col) {

        Destroy(col.gameObject);
	}
}
