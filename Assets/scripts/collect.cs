using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class collect : MonoBehaviour
{
    float wait;
    bool hit;
    public GameObject pumpkin;


    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHit();
        Roll();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hit = true;
            wait = 0.2f;
        }
    }

    void Roll()
    {

        if (hit == false)
        {
            float angularChangeInDegrees = -50; //Changes the rolling speed of the pumpkin
            var body = GetComponent<Rigidbody2D>();
            var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * body.inertia;
            body.AddTorque(impulse, ForceMode2D.Force);
        }
    }

    void CheckForHit()
    { 
        if (hit)
        { 
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);

            wait-=Time.deltaTime;

            if( wait < 0 )
            {
                Destroy(gameObject);
            }
        }
    }
     
      
    


}
