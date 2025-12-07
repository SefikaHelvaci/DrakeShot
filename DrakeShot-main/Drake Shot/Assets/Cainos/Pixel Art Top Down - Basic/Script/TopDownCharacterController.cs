using UnityEngine;

namespace Cainos.Pixel_Art_Top_Down___Basic.Script
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public PlayerScript myPlayer;

        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
            }

            dir.Normalize();

            GetComponent<Rigidbody2D>().linearVelocity = myPlayer.playerSpeed * dir;
        }
    }
}
