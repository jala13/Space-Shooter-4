using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController controller;

    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

        GameObject tmpExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(tmpExplosion, 1);
        if (other.tag != "Player")
        {
            controller.AddScore(10);
        }

        if(other.tag == "Player")
        {
            GameObject tmpPlayerExplosion = Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(tmpPlayerExplosion, 1);
            controller.EndGame();
        }
    }
}
