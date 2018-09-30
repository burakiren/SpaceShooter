using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour {

    public GameObject asteroidExpolosion;
    public GameObject playerExpolosion;
    GameObject gameControlObject;
    GameControl gameControl;
	private void Start()
	{
        gameControlObject = GameObject.FindGameObjectWithTag("game_control");
        gameControl = gameControlObject.GetComponent<GameControl>();
	}

	private void OnTriggerEnter(Collider player){

        if(player.tag != "bullet_area") {
            Destroy(player.gameObject);
            Destroy(gameObject);
            Instantiate(asteroidExpolosion, transform.position, transform.rotation);
            gameControl.setScore(10);
        }

        if(player.tag == "Player") {
            Instantiate(playerExpolosion, player.transform.position, player.transform.rotation);
            gameControl.finishGame();
        }

	}
}
