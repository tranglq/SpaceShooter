using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContract : MonoBehaviour {

    public GameObject explosion;
    public GameObject PlayerExposion;
    public int ScoreValue;
    private GameController gameController = new GameController();

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if( gameController == null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if( gameController != null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if(other.tag == "Player")
        {
            Instantiate(PlayerExposion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        
        gameController.AddScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
