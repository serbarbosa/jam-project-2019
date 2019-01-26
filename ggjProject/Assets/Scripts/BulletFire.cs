using UnityEngine;

public class BulletFire : MonoBehaviour{
    
    void OnCollisionEnter(Collision collision) {

        //a bala some ao colidir com qualquer coisa que nao seja o player
        if (collision.collider.tag != "Player") {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(0f, 5f, 0f, ForceMode.VelocityChange);
            Destroy(gameObject, 1f);
        }
        
    }

    private void Update() {
       if( transform.position.y < -1f)
            Destroy(gameObject, 1f);
    }
}
