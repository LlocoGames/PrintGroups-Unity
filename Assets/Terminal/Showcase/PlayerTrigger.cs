using System.Collections;
using System.Collections.Generic;
using Terminal;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            this.Print("Player Triggers!", Terminal.Terminal.PrintGroups.Misc);
        }
    }
}
