using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AnimationStateController : MonoBehaviour
{
    

    [Header("Player Settings")]
    [SerializeField]
    private float speed = 1.0F;
    [SerializeField]
    private float rotateSpeed = 0.3f;

    [Header("Joystick Settings")] 
    [SerializeField]
    private bool snapX;
    [SerializeField] 
    private bool snapY;
    [SerializeField] 
    [Range(0f, 1f)]
    private float deadzone;
    [SerializeField] 
    private bool debugJoystick;
    
    [Header("Dependencies")] 
    [SerializeField]
    private Joystick joystick;
    
    //**Class methods**//
    //animator
    private Animator _animator;
    
    //character controller
    private CharacterController _controller ;
    
    // walking animations
    private int _isWalkingHash;
    private int _isWalkingBackwardsHash;
    private int _isRightTurnHash;
    private int _isLeftTurnHash;
    
    //abilities
    private int _isDancingHash;
    private bool _dancePressed;

    //For timer
    private bool _isFirstMove;
    
    //for debugger
    private GUIStyle _guiStyle;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        _isDancingHash = Animator.StringToHash("isDancing");
        _isRightTurnHash = Animator.StringToHash("isRightTurn");
        _isLeftTurnHash = Animator.StringToHash("isLeftTurn");

        _isFirstMove = false;
        _dancePressed = false;
        Time.timeScale = 1f;

        joystick.DeadZone = deadzone;
        joystick.SnapX = snapX;
        joystick.SnapY = snapY;

        //for joystick debugger
        _guiStyle = new GUIStyle
        {
            fontSize = 100,
            fontStyle = FontStyle.Bold,
            normal = {textColor = Color.black},
        };
    }
    
    private void FixedUpdate()
    {
        bool isHorizontalBigger = Mathf.Abs(joystick.Horizontal) > Mathf.Abs(joystick.Vertical);
        bool isNotMoving = joystick.Horizontal == 0 &&  joystick.Vertical == 0;
        
        if ( !isNotMoving && !_isFirstMove)
        {
            Timer.GetInstance().BeginTimer();
            _isFirstMove = true;
        }

        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool forwardPressed = joystick.Vertical > 0 && !isHorizontalBigger;;
        
        if (!isWalking && forwardPressed)
        {
            _animator.SetBool(_isWalkingHash, true);
            /* Insert walking sounds here*/
        }
        if (isWalking && !forwardPressed)
        {
            _animator.SetBool(_isWalkingHash, false);
        }


        bool isWalkingBackwards = _animator.GetBool(_isWalkingBackwardsHash);
        bool backwardPressed = joystick.Vertical < 0 && !isHorizontalBigger;
        
        if (!isWalkingBackwards && backwardPressed)
        {
            _animator.SetBool(_isWalkingBackwardsHash, true);
            /* Insert walking sounds here*/
        }
        if (isWalkingBackwards && !backwardPressed)
        {
            _animator.SetBool(_isWalkingBackwardsHash, false);
        }


        bool isDancing = _animator.GetBool(_isDancingHash);
        //bool dancePressed = Input.GetKey("f");
        
        if (!isDancing && _dancePressed)
        {
            _animator.SetBool(_isDancingHash, true);
            /* Insert dancing sound here*/
        }
        if (isDancing && !_dancePressed)
        {
            _animator.SetBool(_isDancingHash, false);
        }


        bool isRightTurn = _animator.GetBool(_isRightTurnHash);
        bool rightPressed = joystick.Horizontal > 0 && isHorizontalBigger;
        
        if (!isRightTurn && rightPressed)
        {
            _animator.SetBool(_isRightTurnHash, true);
            /*  insert rotate character sound here */
        }
        if (isRightTurn && !rightPressed)
        {
            _animator.SetBool(_isRightTurnHash, false);
        }


        bool isLeftTurn = _animator.GetBool(_isLeftTurnHash);
        bool leftPressed = joystick.Horizontal < 0 && isHorizontalBigger;
        
        if (!isLeftTurn && leftPressed)
        {
            _animator.SetBool(_isLeftTurnHash, true);
            /*  insert rotate character sound here */
        }
        if (isLeftTurn && !leftPressed)
        {
            _animator.SetBool(_isLeftTurnHash, false);
        }

        //joystick speed for animator speed
         if (isHorizontalBigger && !isNotMoving)
         {
             _animator.speed = Mathf.Abs(joystick.Horizontal);
         }
         else if(!isHorizontalBigger && !isNotMoving)
         {
             _animator.speed = Mathf.Abs(joystick.Vertical);
         }
         else
         {
             _animator.speed = 1f;
         }

         bool isAnimRunning = isWalking || isWalkingBackwards || isRightTurn || isLeftTurn;
         if(isDancing && !isNotMoving ) return;
         
         // Rotate around y - axis
        transform.Rotate(0, joystick.Horizontal * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * joystick.Vertical;
        _controller.SimpleMove(forward * curSpeed);

    }

    private void OnGUI()
    {
        if (!debugJoystick) return;

        GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 100, 50),
            $"Vertical: {Mathf.Round(joystick.Vertical * 100.0f) * 0.01f}", _guiStyle);
        
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50,100, 50),
            $"Horizontal: {Mathf.Round(joystick.Horizontal * 100.0f) * 0.01f}",_guiStyle);
    }

    public void setDance(bool dance)
    {
        if (_animator.GetBool(_isWalkingHash) || _animator.GetBool(_isWalkingBackwardsHash) ||
            _animator.GetBool(_isLeftTurnHash) || _animator.GetBool(_isRightTurnHash))
            _dancePressed = false;
        else
        {
            _dancePressed = dance;
        }
    }
    
}
