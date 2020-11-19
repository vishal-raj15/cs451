using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidspwan2 : MonoBehaviour
{
    // public float min_y = 5f , max_y = 17f;
    public GameObject[] asteroid_prefabs;
    public GameObject enemyPrefab;

    public float timer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawn", timer);
    }

    // Update is called once per frame
    void spawn()
    {
        Camera maincam = GameObject.Find("Main Camera").GetComponent<Camera>();

        float posy = Random.Range( maincam.transform.position.y+5.0f ,maincam.transform.position.y+15.0f);
       

        Vector3 temp = transform.position;
        temp.y = posy;

        if( Random.Range(0,2) > 0){

            Instantiate( asteroid_prefabs[ Random.Range( 0, asteroid_prefabs.Length)],
            temp , Quaternion.identity);
        }

        Invoke("spawn", timer);
    }
}
