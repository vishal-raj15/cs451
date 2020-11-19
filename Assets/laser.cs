using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform firePoint;
    public float damage = 3.0f;
    public LineRenderer linerenderer;

    public AudioClip lasersound;

    public AudioClip rockBoom;
    // Update is called once per frame

    void Start(){
        linerenderer.enabled = false;
    }

    private void Update(){

        AudioSource laser = GetComponent<AudioSource>();
        AudioSource rockblast = GetComponent<AudioSource>();
       // Debug.DrawRay( firePoint.position ,  transform.up*10f , Color.red);
        RaycastHit2D hitinfo = Physics2D.Raycast( firePoint.position, transform.up);
        linerenderer.SetPosition(0, firePoint.position);

        if( Input.GetKeyDown(KeyCode.Space))
        {

            laser.PlayOneShot(lasersound);
            linerenderer.enabled = true;


        }
        if(  Input.GetKeyUp(KeyCode.Space)){
            linerenderer.enabled = false;
        }
        if( hitinfo){
            linerenderer.SetPosition(1, hitinfo.point);
        }
        else{
            linerenderer.SetPosition(1, firePoint.position+transform.up*50f);
        }


        if( linerenderer.enabled== true){
            //Debug.Log( hitinfo.collider.name);
            asteroid a1 = hitinfo.transform.GetComponent<asteroid>();
            if( a1 != null){
                a1.takeDamage(damage);
                if( a1.health <= 0)
                {
                    rockblast.PlayOneShot(rockBoom);
                   // Debug.Log(" its destriying the rocks");
                }
            }

        }

    }
















    // void Update()
    // {
    //     if( Input.GetKeyDown(KeyCode.Space))
    //     {  
    //     //    StartCoroutine(Shoot());
    //         Shoot();
    //     }
    // }

    // void Shoot(){
    //     Debug.DrawRay( firePoint.position , firePoint.TransformDirection( Vector2.up)*10f , Color.red);
    //     RaycastHit2D hitinfo = Physics2D.Raycast( firePoint.position, firePoint.TransformDirection( Vector2.up) ,10f);
        
    //     if( hitinfo){
    //         Debug.Log( hitinfo.collider.name);
    //         // if( hitinfo.collider ==)

             

    //         asteroid a1 = hitinfo.transform.GetComponent<asteroid>();
    //         if( a1 != null){
    //             a1.takeDamage(damage);
    //         }
    //         linerenderer.SetPosition(0, firePoint.position);
    //         linerenderer.SetPosition( 1, hitinfo.point);

    //     }

    //     else{
    //          linerenderer.SetPosition(0, firePoint.position);
    //         linerenderer.SetPosition( 1, firePoint.position +  firePoint.TransformDirection( Vector2.up));
    //     }

    //     // linerenderer.enabled = true;
    //     // yield return 0; 
    //     // linerenderer.enabled = false;
    // }


    
// }

}