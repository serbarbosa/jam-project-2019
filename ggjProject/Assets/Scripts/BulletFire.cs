using UnityEngine;

public class BulletFire : MonoBehaviour{

    Rigidbody rb;

    void OnCollisionEnter(Collision collision) {
        Debug.Log($"We hit {collision.collider.name}");
        //a bala some ao colidir com qualquer coisa que nao seja o player
        if (collision.collider.tag != "Player" || transform.position.y < 0f) {
            Destroy(gameObject, 1f);
        }
    }
    

}
