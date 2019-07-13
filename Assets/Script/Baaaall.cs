using UnityEngine;

public class Baaaall : MonoBehaviour {

    public GameObject ball;
    public static float delay;
    private float nextSpawn;

    void Start()
    {
        delay = 1.2f*(.9f/PlayerPrefs.GetFloat("speed"));
        nextSpawn = Time.time + .5f;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + delay;
            Instantiate(ball, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}
