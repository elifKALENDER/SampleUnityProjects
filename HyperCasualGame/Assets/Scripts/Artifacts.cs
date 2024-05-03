using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifacts : MonoBehaviour
{
    public int minScore,maxScore;
    private gameSceneSwitcher gameManager;

    void Start()
    {
        gameManager=FindObjectOfType<gameSceneSwitcher>();
    }

    private void Update() {

        transform.Rotate(0f, 0f, 180f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {

            gameManager.AddScore(Random.Range(minScore, maxScore));
            Destroy(gameObject);
        }
        

    }


}
