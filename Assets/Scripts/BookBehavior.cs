using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookBehavior : MonoBehaviour
{
    public GameObject bookCanvas;
    public Text bookText;
    public Button closeButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            // Show book canvas and set text
            bookCanvas.SetActive(true);
            

            // Add listener to close button
            closeButton.onClick.AddListener(CloseBook);
        }
    }

    public void CloseBook()
    {

        // Destroy book object and canvas
        Destroy(gameObject);
        Destroy(bookCanvas);
    }
}
