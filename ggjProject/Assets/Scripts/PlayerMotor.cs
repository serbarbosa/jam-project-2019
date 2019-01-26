using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour{

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float jumpForce = 200f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currCameraRotationX = 0f;

    [SerializeField]
    private float cameraRotationLimit = 50f;

    private Rigidbody rb;
    
    void Start() {
        rb = GetComponent<Rigidbody>();    
    }

    public void Move(Vector3 _velocity) {
        velocity = _velocity;

    }

    public void Rotate(Vector3 _rotation) {
        rotation = _rotation;
    }

    public void RotateCamera(float _cameraRotationX) {
        cameraRotationX = _cameraRotationX;
    }

    public void PerformJump() {
        rb.AddForce(0f, jumpForce * Time.deltaTime, 0f, ForceMode.VelocityChange);
    }

    private void FixedUpdate() {
        PerformMovement();
        PerformRotation();

    }

    private void PerformMovement() {

        if(velocity != Vector3.zero) {
            //faz os testes de colisoes e melhor do que AddForce
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation() {

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation) );

        if(cam != null) {
            //definindo rotaçao da camera e limitando em 80°
            currCameraRotationX -= cameraRotationX;
            currCameraRotationX = Mathf.Clamp(currCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currCameraRotationX, 0f, 0f);
            
        }
    }

    private void OnCollisionEnter(Collision collision) {
        //se player colide com o chao e estava pulando, entao nao esta mais
        PlayerController pc = GetComponent<PlayerController>();
        if (pc.isJumping && collision.collider.tag == "Ground")
            pc.isJumping = false;

    }

}
