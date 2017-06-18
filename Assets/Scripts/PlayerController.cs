using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    // Public variable, editable in the inspector
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    // Start - Called on the first frame the game is active
    // first frame of the game.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // FixedUpdate - Called just before performing any physics calculations
    // Where physics calculations go.
    void FixedUpdate()
    {
        Vector3 movement = Movement(speed);
        rb.AddForce(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagNames.PickUp))
        {
            other.gameObject.SetActive(false);
            ++count;
            SetCountText();
        }
    }

    private Vector3 Movement(float speed)
    {
        float moveHorizontal = Input.GetAxis(AxisNames.Horizontal);
        float moveVertical = Input.GetAxis(AxisNames.Vertical);

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        return movement * speed;
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}

// String Enum for axis names
static class AxisNames
{
    public static string Horizontal
    {
        get
        {
            return "Horizontal";
        }
    }

    public static string Vertical
    {
        get
        {
            return "Vertical";
        }
    }
}

// Tag names we want to check for (the ones we care about in this file)
// Also a string enum
static class TagNames
{
    public static string Player
    {
        get
        {
            return "Player";
        }
    }

    public static string PickUp
    {
        get
        {
            return "Pick Up";
        }
    }
}
