using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Player thePlayer;

    public SpriteRenderer theSR;
    public Sprite doorOpen;

    public bool dooropen, waitToOpen;
    public GameObject gameOver;
  

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitToOpen)
        {
            if(Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 0.01f)
            {
                waitToOpen = false;

                dooropen = true;

                theSR.sprite = doorOpen;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
            }
        }

        if (dooropen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1f && Input.GetAxis("Vertical") > 0.1f)
        {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameOver.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitToOpen = true;
            }
        }
    }
}
