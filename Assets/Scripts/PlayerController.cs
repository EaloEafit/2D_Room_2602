
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasKey = false;
    public bool hasWater = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            score = score + 1;
            Debug.Log("Score: " + score);
                       
				
		}
		if (other.CompareTag("Key"))
        {
            hasKey = true;
			Debug.Log("You got the Key!");
			Destroy(other.gameObject);
		}
		if (other.CompareTag("Water"))
		{
			hasWater = true;
			Debug.Log("You has touched the water and cannot win");
			
		}


		// WIN condition
		if (score >= 3 && hasKey == true && !hasWater)
		{
			Debug.Log("You Won!");
		}
		

	}


}
