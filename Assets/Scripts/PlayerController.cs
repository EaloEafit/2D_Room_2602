
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasKey = false;
    public bool hasWater = false;
    public TextMeshProUGUI textScore;
	public TextMeshProUGUI notificationText;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        UpdateTextScore();
    }

    // Update is called once per frame
    void Update()
    {
       // Leemos la entrada del teclado WASD o Flechas
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
       transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            Debug.Log("Collected!");
            ShowNotification("Collected!");
            score = score + 1;
            UpdateTextScore();
            Debug.Log("Score: " + score);
                       
				
		}
		if (other.CompareTag("Key"))
        {
            hasKey = true;
			Debug.Log("You got the Key!");
			ShowNotification("You got the Key!");
			Destroy(other.gameObject);
		}
		if (other.CompareTag("Water"))
		{
			hasWater = true;
			Debug.Log("You has touched the water and cannot win");
			ShowNotification("You has touched the water and cannot win");
		}


		// WIN condition
		if (score >= 3 && hasKey == true && !hasWater)
		{
			Debug.Log("You Won!");
			ShowNotification("You Won!");
		}
		

	}
    void UpdateTextScore ()
    {
        textScore.text = "Score: " + score;
    }

    void ShowNotification(string message)
    {
        notificationText.text = message;
    }



}
