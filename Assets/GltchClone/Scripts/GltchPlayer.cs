using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GltchPlayer : MonoBehaviour
{

    GltchAnimation _GltchAnimation;


    private Vector2Int gridMoveDirection;
    [SerializeField]
    private Vector2 gridPosition;
    private Vector2 oldGridPosition;

    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;

    private bool isMoving = false;
    private bool isDirPressed = false;
    private bool isReverseDir = false;

    private int isLastDirY = 0;
    private int isLastDirX = 0;



    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }

    private void Awake()
    {
        _GltchAnimation = GameObject.FindObjectOfType<GltchAnimation>();

        gridPosition = new Vector2Int(3, 6);
        oldGridPosition = gridPosition;

        gridMoveTimerMax = 0.1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(0, 1);
    }

    private void Start()
    {
        isMoving = false;
    }

    private void Update()
    {
        HandleInput();
        OnTapClicked();
        HandleGridMovement();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpMove();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownMove();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftMove();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMove();
        }
    }

    void OnEnable()
    {
        TouchSwipeDetector.onSwipeUp += OnSwipeUp;
        TouchSwipeDetector.onSwipeRight += OnSwipeRight;
        TouchSwipeDetector.onSwipeLeft += OnSwipeLeft;
        TouchSwipeDetector.onSwipeDown += OnSwipeDown;
        TouchSwipeDetector.onTapClick += OnTapClicked;
    }

    private void OnDisable()
    {
        TouchSwipeDetector.onSwipeUp -= OnSwipeUp;
        TouchSwipeDetector.onSwipeRight -= OnSwipeRight;
        TouchSwipeDetector.onSwipeLeft -= OnSwipeLeft;
        TouchSwipeDetector.onSwipeDown -= OnSwipeDown;
        TouchSwipeDetector.onTapClick -= OnTapClicked;
    }


    void OnSwipeUp()
    {
        UpMove();
    }

    void OnSwipeDown()
    {
        DownMove();
    }

    void OnSwipeLeft()
    {
        LeftMove();
    }

    void OnSwipeRight()
    {
        RightMove();
    }

    void OnTapClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }


    void UpMove()
    {
        if (isLastDirY != 1)
        {
            _GltchAnimation.BlinkStart();
            isMoving = true;
            isDirPressed = true;

            if (Math.Abs(isLastDirY) != 0)
            {
                isReverseDir = true;

                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
                ChnageDir(gridMoveDirection);
            }
            else
            {
                isReverseDir = false;

                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
            }
        }
    }

    void DownMove()
    {
        if (isLastDirY != -1)
        {
            _GltchAnimation.BlinkStart();
            isMoving = true;
            isDirPressed = true;

            if (Math.Abs(isLastDirY) != 0)
            {
                isReverseDir = true;

                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
                ChnageDir(gridMoveDirection);
            }
            else
            {
                isReverseDir = false;

                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
    }

    void LeftMove()
    {
        if (isLastDirX != -1)
        {
            _GltchAnimation.BlinkStart();
            isMoving = true;
            isDirPressed = true;

            if (Math.Abs(isLastDirX) != 0)
            {
                isReverseDir = true;

                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
                ChnageDir(gridMoveDirection);
            }
            else
            {
                isReverseDir = false;

                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
    }

    void RightMove()
    {
        if (isLastDirX != 1)
        {
            _GltchAnimation.BlinkStart();
            isMoving = true;
            isDirPressed = true;

            if (Math.Abs(isLastDirX) != 0)
            {
                isReverseDir = true;

                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
                ChnageDir(gridMoveDirection);
            }
            else
            {
                isReverseDir = false;

                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }
        }
    }

    private void HandleGridMovement()
    {
        if (!isMoving)
            return;


        isLastDirX = gridMoveDirection.x;
        isLastDirY = gridMoveDirection.y;

        if ((gridPosition.x == transform.position.x && gridPosition.y == transform.position.y) || isReverseDir == true)
        {
            isDirPressed = false;
            isReverseDir = false;

            gridPosition += gridMoveDirection;
            gridPosition = levelGrid.ValidateGridPosition(gridPosition);

            ChnageDir(gridMoveDirection);
        }
        else if(isDirPressed)
        {
            transform.position = Vector2.MoveTowards(transform.position, gridPosition, 3f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, gridPosition, 2f * Time.deltaTime);
        }
    }

    void ChnageDir(Vector2Int gridMoveDirection)
    {
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public Vector2 GetGridPosition()
    {
        return gridPosition;
    }
}
