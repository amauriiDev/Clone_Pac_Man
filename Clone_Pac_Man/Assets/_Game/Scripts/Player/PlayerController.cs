using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private AnimatorController animatorController;
    private Rigidbody2D rigid;
    private PlayerInput input;

    private Vector2 MoveAxis;

    [SerializeField]private float velocity;
    void Start()
    {
        animatorController = GetComponentInChildren<AnimatorController>();
        rigid = GetComponent<Rigidbody2D>();
        input = new PlayerInput();
        MoveAxis = Vector2.zero;
    }

    
    void FixedUpdate()
    {
        rigid.velocity = MoveAxis * velocity * Time.fixedDeltaTime;
    }

    public void Movement(InputAction.CallbackContext context){
        if(context.performed){
            MoveAxis = (context.ReadValue<Vector2>());
            animatorController.AnimateMovement(MoveAxis);
        }
    }
}
