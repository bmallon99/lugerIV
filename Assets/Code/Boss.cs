using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private UnityEngine.Object _B;
    private int hp;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = 1000;
        _B = Resources.Load("B");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
        {
            makeB();
        }
    }

    public void makeB()
    {
        Instantiate(_B, gameObject.transform.position, new Quaternion());
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp--;
        }
    }
}
