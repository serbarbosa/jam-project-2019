using UnityEngine;

public class BulletFire : MonoBehaviour{

    void OnCollisionEnter(Collision collision) {
        Debug.Log($"We hit {collision.collider.name}");
        //a bala some ao colidir com qualquer coisa que nao seja o player
        if (collision.collider.tag != "Player") {
            Destroy(gameObject, 1f);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(0f, 5f, 0f, ForceMode.VelocityChange);
        }

    }

    private void Update() {
        if (transform.position.y < -1f)
            Destroy(gameObject);
    }

}
