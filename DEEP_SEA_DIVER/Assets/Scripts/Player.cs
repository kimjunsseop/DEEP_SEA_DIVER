using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public float Speed {get;set;}
    private bool isBreathing = false;
    public Dictionary<int, bool> inventory = new Dictionary<int, bool>();
    public int inventorySize = 3;
    void Start()
    {
        Speed = 3f;
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        SetAnim(h,v);
        transform.Translate(new Vector3(h,v,0) * Speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        Vector3 newOffset = Camera.main.WorldToViewportPoint(transform.position);
        newOffset.x = Mathf.Clamp01(newOffset.x);
        newOffset.y = Mathf.Clamp01(newOffset.y);
        Vector3 world = Camera.main.ViewportToWorldPoint(newOffset);
        transform.position = world;
    }
    void SetAnim(float h, float v)
    {
        if(h > 0 && !isBreathing)
        {
            anim.SetBool("Right", true);
        }
        else if(h < 0 && !isBreathing)
        {
            anim.SetBool("Left", true);
        }
        else
        {
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }

        if(v > 0 && !isBreathing)
        {
            anim.SetBool("Up", true);
        }
        else if(v < 0)
        {
            anim.SetBool("Down", true);
        }
        else
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
        }
    }
    public void InitializeInventory()
    {
        for(int i = 0; i < inventorySize; i++)
        {
            int rand = Random.Range(0, 3);
            if(inventory.ContainsKey(rand))
            {
                i--;
               continue; 
            }
            inventory.Add(rand, false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SaftyZone"))
        {
            isBreathing = true;
        }
        if(collision.CompareTag("Item"))
        {
            // ui 활성화
            if(Input.GetKeyDown(KeyCode.Space))
            {
                inventory[collision.GetComponent<Item>().itemType] = true;
                collision.GetComponent<Item>().Pickuped();
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("SaftyZone"))
        {
            isBreathing = false;
        }
    }
}
