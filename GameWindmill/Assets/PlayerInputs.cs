using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    Animator _animator;
    [SerializeField]
    Rigidbody2D rg;
    [SerializeField]
    BoxCollider2D bc;
    private Vector2 moveInput;
    private float sprint = 1.0f;
    bool IsSprinting;

    public void Jump(InputAction.CallbackContext cntxt) //Jumping Function
    {
        //cntxt started, performed, cancelled
        if (cntxt.started)
        {
            Debug.Log(cntxt.phase);
            rg.AddForce(new Vector2(0, 200));
        }
    }
    /*public bool Sprint(InputAction.CallbackContext cntxt)
    {
        sprint = 10.0f;
    }*/

    public void OnMovement(InputAction.CallbackContext cntxt) //Movement Function
    {
        moveInput = cntxt.ReadValue<Vector2>(); //Reads Value

    }
    public void Crouch()
    {
        bc.offset = new Vector2(-0.05f, 0.2773157f);
        bc.size = new Vector2(0.1937763f, 0.5646315f);
    }
    public void UnCrouch()
    {
        bc.offset = new Vector2(-0.05f, 0.45f);
        bc.size = new Vector2(0.1937763f, 0.91f);
    }
    /*void SprintPressed()
    {
        IsSprinting = true;
    }
    void SprintReleased()
    {
        IsSprinting = false;
    }
    private void Start()
    {
        moveInput.Sprint.performed += x => SprintPressed();
        moveInput.Sprint.canceled += x = SprintReleased();
    }*/
    public void CrouchorUnCrouch()
    {
        if (moveInput.y < 0)
        {

            Crouch();
            _animator.SetBool("IsCrouch", true);
        }
        else
        {
            UnCrouch();
            _animator.SetBool("IsCrouch", false);
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.shift) == true)
        {
            sprint = 10.0f;
        }
        else
        {
            sprint = 1.0f;
        }*/
        CrouchorUnCrouch();
        rg.linearVelocity = new Vector3(moveInput.x * sprint, rg.linearVelocity.y, moveInput.y);

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
