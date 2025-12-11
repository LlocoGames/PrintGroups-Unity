using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terminal.Demo {
    public class Controller : MonoBehaviour {
        [Header("Components")]
        [SerializeField] Rigidbody2D rb;

        [Header("Settings")]
        [SerializeField] float horizontalMov;
        [SerializeField] float maxHorizontalAcceleration = 10;
        [SerializeField] float jump;
        Vector2 dir;
        Vector2 deltaDir;

        enum PrintSubGroup {
            Inputs,
            Movement
        }

        private void Start() {
            this.Print("Player spawned!", Terminal.PrintGroups.Player);
        }

        private void FixedUpdate() {
            GetInput();

            Vector2 force = Vector2.right * dir.x * horizontalMov;
            rb.AddForce(force);

            Vector3 v = rb.velocity;
            v.y = 0;
            v = Vector2.ClampMagnitude(v, maxHorizontalAcceleration);

            rb.velocity = new Vector2(v.x, rb.velocity.y);

            if(deltaDir.y > 0 && dir.y > 0) {
                OnJump();
            }
        }

        void GetInput() {
            Vector2 tempDir;
            tempDir.x = Input.GetAxisRaw("Horizontal");
            tempDir.y = Input.GetAxisRaw("Vertical");

            deltaDir = tempDir - dir;
            dir = tempDir;

            if(deltaDir != Vector2.zero) this.Print(deltaDir, Terminal.PrintGroups.Player, PrintSubGroup.Inputs);
        }

        void OnJump() {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            this.Print("Jump!", Terminal.PrintGroups.Player, PrintSubGroup.Movement);
        }
    }

}