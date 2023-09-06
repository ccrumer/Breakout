using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private InputAction move;
    private InputAction restart;
    private InputAction quit;
    private bool isPaddleMoving;
    [SerializeField] private GameObject paddle;
    [SerializeField] private float paddleSpeed;
    private float moveDirection;
    [SerializeField] private GameObject brick;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score;
    [SerializeField] private TMP_Text endGameText;
    [SerializeField] BallController ball ;

    void Start()
    {
        //create brick 
        NewMethod();

        //activating the action map
        DefinePlayerMovement();
        endGameText.gameObject.SetActive(false);
        
        isPaddleMoving = false;

        void NewMethod()
        {
            Vector2 brickPos = new Vector2(-9, 4.5f);
            for (int j = 0; j < 4; j++)
            {
                brickPos.y -= 1;
                brickPos.x = -9;

                for (int i = 0; i < 10; i++)
                {
                    brickPos.x += 1.6f;
                    Instantiate(brick, brickPos, Quaternion.identity);

                }
            }
        }

        void DefinePlayerMovement()
        {
            playerInput.currentActionMap.Enable();

            move = playerInput.currentActionMap.FindAction("MovePaddle");
            restart = playerInput.currentActionMap.FindAction("Restart");
            quit = playerInput.currentActionMap.FindAction("Quit");


            move.started += Move_started;
            restart.started += Restart_started;
            quit.started += Quit_started;
            move.canceled += Move_canceled;
        }
    }
    public void UpdateScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
        if(score>=4000)
        {
            endGameText.text = "YOU WIN!!!";
            endGameText.gameObject.SetActive(true);
            ball.ResetBall();

        }
    }


    private void Quit_started(InputAction.CallbackContext obj)
{

}
private void Move_started(InputAction.CallbackContext obj)
{
    isPaddleMoving = true;
}
private void Restart_started(InputAction.CallbackContext obj)
{

}
private void Move_canceled(InputAction.CallbackContext obj)
{
    isPaddleMoving = false;
}
// Start is called before the first frame update
private void FixedUpdate()
{
    if (isPaddleMoving)
    {
        //move paddle
        paddle.GetComponent<Rigidbody2D>().velocity= new Vector2 (paddleSpeed*moveDirection,0);
    }
    else
    {
            //stop the padld
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
    // Update is called once per frame
    void Update()
    {
        if(isPaddleMoving)
        {
            moveDirection = move.ReadValue<float>();
        }
    }
}
