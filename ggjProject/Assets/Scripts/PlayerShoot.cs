using UnityEngine;

public class PlayerShoot : MonoBehaviour{

    public PlayerWeapon weapon;
    public GameObject Bullet;
    public GameObject bulletSpawn;

    [SerializeField]
    private Camera cam; //necessario ter referencia para o centro da camera permitindo gerar o raio do tiro

    [SerializeField]
    private LayerMask mask; //camada de objetos possiveis de acertar com tiro

    private void Start() {
        if (cam == null) {
            Debug.Log("No camera reference found!");
            this.enabled = false;
        }
    }

    private void Update() {
        if(Input.GetButton("Fire1") && Time.time > weapon.nextTimeToFire) {
            weapon.nextTimeToFire = Time.time + 1f / weapon.cooldown;
            Shoot();
        }
    }

    private void Shoot() {

        weapon.muzzleFlash.Play();

        GameObject bullet = Instantiate(Bullet, bulletSpawn.transform.position , cam.transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(cam.transform.forward * weapon.range, ForceMode.VelocityChange);
    }

}
