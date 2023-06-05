using UnityEngine;

namespace Scenes.Brick_Breaker_2._Scripts {
    public class BallInitializer : MonoBehaviour {
        private Rigidbody2D MyRb { get; set; }
        public float speed = 500f;
        public AudioSource touchBrickSound;

        private void Awake() {
            MyRb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            Invoke(nameof(SetRandomTrajectory), 1f);
        }

        private void SetRandomTrajectory() {
            float x;
            Vector2 force = Vector2.zero;
            do
            {
                 x = Random.Range(-1f, 1f);
            } while (x > -0.5 && x < 0.5);
            
            force.x = x;
            force.y = -1;
        
            MyRb.AddForce(force.normalized * speed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("brick1"))
            {
                FindObjectOfType<ManageGame>().P1LoseBrick();
                touchBrickSound.Play();
            }else if (collision.gameObject.CompareTag("brick2"))
            {
                FindObjectOfType<ManageGame>().P2LoseBrick();
                touchBrickSound.Play();
            }
        }

        
    }
}
