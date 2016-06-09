using UnityEngine;
using System.Collections;

public class DisappearObject : MonoBehaviour {

    public float time;
    public bool drop;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Invoke("disappear", time);
        }
        if (drop)
        {
            if (obj.gameObject.tag == "Ground")
            {
                Invoke("disappear", time);
            }
        }
    }
    void disappear()
    {
        gameObject.SetActive(false);
    }
}
