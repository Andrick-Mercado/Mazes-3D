using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isWalkingBackwardsHash;
    int isDancingHash;
    int isRightTurnHash;
    int isLeftTurnHash;

    bool isFirstMove;

    public float speed = 1.0F;
    public float rotateSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        isFirstMove = false;
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        isDancingHash = Animator.StringToHash("isDancing");
        isRightTurnHash = Animator.StringToHash("isRightTurn");
        isLeftTurnHash = Animator.StringToHash("isLeftTurn");



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) && !isFirstMove)
        {
            Timer.GetInstance().BeginTimer();
            isFirstMove = true;
        }
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w");
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
            /* Insert walking sounds here*/
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }


        bool isWalkingBackwards = animator.GetBool("isWalkingBackwards");
        bool backwardPressed = Input.GetKey("s");
        if (!isWalkingBackwards && backwardPressed)
        {
            animator.SetBool(isWalkingBackwardsHash, true);
            /* Insert walking sounds here*/
        }
        if (isWalkingBackwards && !backwardPressed)
        {
            animator.SetBool(isWalkingBackwardsHash, false);
        }


        bool isDancing = animator.GetBool("isDancing");
        bool dancePressed = Input.GetKey("f");
        if (!isDancing && dancePressed)
        {
            animator.SetBool(isDancingHash, true);
            /* Insert dancing sound here*/
        }
        if (isDancing && !dancePressed)
        {
            animator.SetBool(isDancingHash, false);
        }


        bool isRightTurn = animator.GetBool("isRightTurn");
        bool RightPressed = Input.GetKey("d");
        if (!isRightTurn && RightPressed)
        {
            animator.SetBool(isRightTurnHash, true);
            /*  insert rotate character sound here */
        }
        if (isRightTurn && !RightPressed)
        {
            animator.SetBool(isRightTurnHash, false);
        }


        bool isLeftTurn = animator.GetBool("isLeftTurn");
        bool LeftPressed = Input.GetKey("a");
        if (!isLeftTurn && LeftPressed)
        {
            animator.SetBool(isLeftTurnHash, true);
            /*  insert rotate character sound here */
        }
        if (isLeftTurn && !LeftPressed)
        {
            animator.SetBool(isLeftTurnHash, false);
        }


        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed*10f, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);


    }

    
}
