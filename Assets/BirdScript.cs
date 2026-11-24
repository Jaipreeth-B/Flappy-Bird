using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool BirdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && BirdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }
        if(transform.position.y > 20 || transform.position.y < -20)
        {
            logic.GameOver();
            BirdIsAlive = false;
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        BirdIsAlive = false;
    }
}