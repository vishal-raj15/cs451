using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private Camera mainCamera;
    public float speed = 2.0f;
    public float rotate_speed = 20f;
    public bool canRotate;
    private bool canmove = true;
    public float bound_x = -15f;
    public float health = 100f;
    public GameObject deathEff;
    public Transform explosion;

    private Rigidbody2D rb;
    private Vector2 screenbound;
    private AudioSource asteroidBlast;
    // Start is called before the first frame update

    void Awake()
    {
         asteroidBlast = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2( -speed ,0);
        // Camera maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
       

        if ( canRotate){
            if( Random.Range(0,2) > 0){
                rotate_speed = Random.Range( rotate_speed, rotate_speed + 20f);
                rotate_speed *= -1f;
            }

            else{
                rotate_speed = Random.Range( rotate_speed, rotate_speed + 20f);
            }
        }

        // if( rb.transform.position.x < maincam.transform.position.x){
        //     // gameObject.SetActive( false);
        //     Debug.Log( " get out fucker");
        // }
        // screenbound = mainCamera.ScreenToWorldPoint( new Vector3( transform.position.x , transform.position.y , -10f));
        //    Debug.Log( " positon of aster : ");
           
        //     Debug.Log(transform.position.x);
           
            // Debug.Log( " positon is : ");
           
            // Debug.Log(maincam.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log( " positon of aster : ");
           
        //     Debug.Log(transform.position.x);
       move();
        Rotateas();
        
    }


    //////////////////////////////////

    public void takeDamage( float damage){

        health -= damage;

        if( health <= 0){
            
            Blast();
            
        }
    }

    void Blast(){
        // Instantiate( deathEff , transform.position, Quaternion.identity);
       
       if(explosion)
{
  GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
  Destroy(exploder, 1.0f);
  
}
        Destroy( gameObject);
       // asteroidBlast.Play();


    }
    /////////////////////////////////////
    void move(){
                Camera maincam = GameObject.Find("Main Camera").GetComponent<Camera>();

        if( canmove){
            Vector3 temp = transform.position;
            temp.x -= speed*Time.deltaTime;
            transform.position = temp;

            if( temp.x < maincam.transform.position.x-6.0f)
                // gameObject.SetActive(false);
                Destroy( gameObject);
        }
    }

    void Rotateas(){
        if( canRotate){
            transform.Rotate( new Vector3( 0f, 0f, rotate_speed* Time.deltaTime), Space.World);
        }
    }



    // void OnBecameInvisible() {
 	// Destroy(gameObject);
// }

}
