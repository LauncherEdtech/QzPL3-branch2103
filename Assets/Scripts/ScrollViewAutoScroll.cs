using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollViewAutoScroll : MonoBehaviour
{
    public Scrollbar scrollbar; // Reference to the vertical Scrollbar

    private void Start()
    {
        // Scroll to the bottom when the script starts
        //ScrollToBottom();
    }

    public void ScrollToBottom()
    {
        StartCoroutine("wait");
    
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        if (scrollbar != null)
        {
            scrollbar.value = 0; // Set the scrollbar's value to 0 to scroll to the bottom
        }
        //script.NextQuestion();
        //anim.SetBool("initial", true);
    }
}
