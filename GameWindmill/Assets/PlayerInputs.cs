using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    Animator _animator;
    [SerializeField]
    Rigidbody2D rg;
    private Vector2 moveInput;

    public void Jump(InputAction.CallbackContext cntxt) //Jumping Function
    {
        //cntxt started, performed, cancelled
        if (cntxt.started)
        {
            Debug.Log(cntxt.phase);
            rg.AddForce(new Vector2(0, 200));
        }
    }

    public void OnMovement(InputAction.CallbackContext cntxt) //Movement Function
    {
        moveInput = cntxt.ReadValue<Vector2>(); //Reads Value
        
    }

    private void Update()
    {
        rg.linearVelocity = new Vector3(moveInput.x, rg.linearVelocity.y, moveInput.y);
        _animator.SetFloat("Speed", moveInput.x);
        if (moveInput.x == 0)
        {
            _animator.SetBool("IsStanding", true);
        }
        else
        {
            _animator.SetBool("IsStanding", false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created\
}
