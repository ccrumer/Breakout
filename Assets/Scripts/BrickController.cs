using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{

    private GameController gameController;
    
    private void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Ball")
        {
            Destroy(gameObject);
        }
       
    }


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
