using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 pos1 = new Vector3(15, 1, -5);

    public Vector3 pos2 = new Vector3(15, 1, 5);

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        pos2 = pos1 + new Vector3(0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
     
            transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);

  
      
      
    }
}
