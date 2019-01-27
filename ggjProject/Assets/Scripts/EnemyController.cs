using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour{

    NavMeshAgent agent;
    public Transform house;

    [SerializeField]
    private float health = 5f;

    private void Start() {
        agent = GetComponent <NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){
        if(agent.enabled)
            MoveToHouse();
    }

    public void MoveToHouse() {
        agent.SetDestination(house.position);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Bullet") {
            TakeDamage();
        }
    }

    public void TakeDamage() {
        this.health -= 1f;
        if (this.health <= 0)
            Die();
    }

    private void Die() {
        Rigidbody rb = GetComponent<Rigidbody>();

        agent.enabled = false;
        rb.mass = 5f;
        rb.AddExplosionForce(2500f, rb.position + new Vector3(0.1f,-0.5f,0.1f), 6f);
        transform.Rotate(0f, 0f, 15f);

        Destroy(this.gameObject, 2.3f);
    }

}
