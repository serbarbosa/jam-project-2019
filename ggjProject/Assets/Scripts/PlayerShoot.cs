using UnityEngine;

public class PlayerShoot : MonoBehaviour{

    public PlayerWeapon weapon;

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
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        //variavel que ira armazenar objeto atingido
        RaycastHit hit;
        //verificando se acertou alguma coisa
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask)) {
            Debug.Log("We hit" + hit.collider.name);
        }
    }

}
