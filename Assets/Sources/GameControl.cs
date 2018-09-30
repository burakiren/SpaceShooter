using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public GameObject asteroid;
    public Vector3 randomAsteroidPosition;
    public float waitingTimeForStart;
    public float waitingTimeForNewAstroid;
    public float waitingTimeForNewAstroidGroup;
    public int score;
    public Text scoreText;
    public Text gameOverText;
    bool isGameFinished = false;
    bool newGameControl = false;

    void Start()
    {
        score = 0;

        if (scoreText != null) {
            scoreText.text = "Score : " + score;
        }
        StartCoroutine(createAsteroid());
     
    }

    void Update() {

        if(Input.GetKeyDown(KeyCode.R) && newGameControl) {

            SceneManager.LoadScene("Level 1");
        }

    }
    IEnumerator createAsteroid() {

        yield return new WaitForSeconds(waitingTimeForStart);

        while (true) {
            
            for (int i = 0; i < 12; i++)
            {
                Vector3 vector = new Vector3(Random.Range(-randomAsteroidPosition.x, randomAsteroidPosition.x), 0, randomAsteroidPosition.z);
                Instantiate(asteroid, vector, Quaternion.identity);
                yield return new WaitForSeconds(waitingTimeForNewAstroid);

            }

            if (isGameFinished){
                newGameControl = true;
                gameOverText.text = "Yeniden başlatmak için lütfen R tuşuna basınız ";
                break;
            }

            yield return new WaitForSeconds(waitingTimeForNewAstroidGroup);

            if (waitingTimeForNewAstroid > 0.1f)
                waitingTimeForNewAstroid -= 0.1f;

            if (waitingTimeForNewAstroidGroup > 0.2f)
                waitingTimeForNewAstroidGroup -= 0.2f;
        }

    }

    public void setScore(int incScore) {
        score += incScore;
        scoreText.text = "Score : " + score;
    }

    public void finishGame() {
        gameOverText.text = "Oyun Bitti.. \n Score : " + score;
        isGameFinished = true;
        
    }
}
