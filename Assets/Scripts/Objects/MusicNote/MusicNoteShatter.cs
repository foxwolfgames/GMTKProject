using UnityEngine;

public class MusicNoteShatter : MonoBehaviour
{
    public float shatterRadius = 7f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a different tag
        if (!collision.gameObject.CompareTag("MusicNote"))
        {
            new NoteShatterEvent(transform.position, shatterRadius).Invoke();
            gameObject.SetActive(false);
        }
    }

    public void Test(Vector3 v, float f)
    {
        print("Shatter");
    }
}