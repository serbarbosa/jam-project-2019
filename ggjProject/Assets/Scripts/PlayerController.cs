using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour{
    [SerializeField]//aparece no inspector mesmo sendo private
    private float speed = 7f;
    [SerializeField]
    private float mouseSensitivity = 3f; 

    private PlayerMotor motor;

    public bool isJumping = false;

    void Start() {
        motor = GetComponent<PlayerMotor>();

    }

    void Update() {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov; //transform.right = (1,0,0)
        Vector3 movVertical = transform.forward * zMov; //transform.right = (0,0,1)
                                                        //vetor apenas com a direcao do movimento
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);

        //Calcular rotacao como 3d vector(apenas ao redor)
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;
        motor.Rotate(rotation);
        
        //Calcular rotacao da camera como 3d vector
        float xRot = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRot * mouseSensitivity; 

        //aplicando a rotacao calculada
        motor.RotateCamera(cameraRotationX);

        //pular se ainda nao estiver pulando
        if (!isJumping) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                isJumping = true;
                motor.PerformJump();
            }
        }
        
    }
}
