using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rg;
    private Vector2 moveInput;

    public void Jump(InputAction.CallbackContext cntxt) //Jumping Function
    {
        //cntxt started, performed, cancelled
        if (cntxt.started)
        {
            Debug.Log(cntxt.phase);
            rg.AddForce(new Vector2(0, 100));
        }
    }

    public void OnMovement(InputAction.CallbackContext cntxt) //Movement Function
    {
        moveInput = cntxt.ReadValue<Vector2>(); //Reads Value
    }

    private void Update()
    {
        rg.linearVelocity = new Vector3(moveInput.x,rg.linearVelocity.y, moveInput.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created\
}
