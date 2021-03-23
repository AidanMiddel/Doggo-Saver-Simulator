using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFoots : MonoBehaviour
{
    public GameObject player;
    PlayerControler playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponentInParent<PlayerControler>();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform") && playerCtrl.isJumping)
        {
            playerCtrl.isJumping = false;
            player.transform.parent = other.gameObject.transform;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
}
