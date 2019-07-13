using UnityEngine;

public class Scaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Screen.width > Screen.height) Screen.orientation = ScreenOrientation.LandscapeLeft;
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        // Set filterMode
        sr.sprite.texture.filterMode = FilterMode.Point;

        // Get stuff
        double width = sr.sprite.bounds.size.x;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Resize
        transform.localScale = new Vector2(1, 1) * (float)(worldScreenWidth / width);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
