using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DialogManager dialogManager;
    public bool isTalking;
    public float speed;
    public bool canTalk;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        if (isTalking == false)
            transform.Translate(h, 0, v);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTalking) 
            {
                dialogManager.NextDialog();
            }

            else if (canTalk && isTalking == false)
            {
                dialogManager.OpenDialog();
                isTalking = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.name == "Ally")

        if (other.GetComponent<NPC>() != null)
        {
            dialogManager.LoadDialogs(other.GetComponent<NPC>().dialogs);
            canTalk = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canTalk = false;
    }
}
