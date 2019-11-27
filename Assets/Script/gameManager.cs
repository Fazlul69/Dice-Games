using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public Sprite[] diceSprite;
    public SpriteRenderer diceRenderer;
    public Transform[] wayPoints;
    bool moveAllow;
    public int randomDiceSlide;
    public int target;
    // Start is called before the first frame update
    void Start()
    {
        diceRenderer.sprite = diceSprite[0];
        moveAllow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            StartCoroutine(diceGenerator());
            moveAllow = true;
        }
        Move();
    }

    IEnumerator diceGenerator() {
        randomDiceSlide = 1;
        for (int i = 0; i < 20; i++) {
            randomDiceSlide = Random.Range(1, 6);
            diceRenderer.sprite = diceSprite[randomDiceSlide];

        }
        yield return new WaitForSeconds(0.05f);
        target += randomDiceSlide;
    }
    
    
    private void Move() {
        if (moveAllow && wayPoints.Length>target) {
            float navigationTime = Time.deltaTime*3;
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[target].position, navigationTime);
        }
        
    }
}
