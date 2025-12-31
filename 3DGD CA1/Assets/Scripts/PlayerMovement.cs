using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public float turnSpeed = 180f;
    public float backSpeed = 2.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        float moveSpeed = Input.GetKey(KeyCode.S) ? backSpeed : speed;
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        controller.Move(move);
    }
}
