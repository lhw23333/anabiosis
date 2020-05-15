using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject nextDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && TpManager.Instance.GetTpState())
        {
            TpManager.Instance.StartTpTimer();
            Tp(collision.gameObject);
        }
    }

    void Tp(GameObject Player)
    {
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Player.transform.position = nextDoor.transform.position;
    }
    
}
