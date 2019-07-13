using UnityEngine;

public class StickMovement : MonoBehaviour {

    public static float speed = 2*BallMovement.speed;
    public static ScoreCounter scoreCount;
    public GameObject stickPopSound;
    private int sound;

	// Use this for initialization
	void Start () {
        sound = PlayerPrefs.GetInt("sound");
        scoreCount = FindObjectOfType<ScoreCounter>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            scoreCount.AddScore(1);
            scoreCount.explode(other.gameObject);
            Destroy(other.gameObject);
            if(sound == 0)
            {
                GameObject sound = Instantiate(stickPopSound, this.transform);
                Destroy(sound, 1);
            }
            

        }
    }
}
