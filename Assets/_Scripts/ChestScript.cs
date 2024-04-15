using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public List<GameObject> itemDrops = new List<GameObject>();
    public GameObject HP_Potion_Prefab;
    public GameObject MP_Potion_Prefab;
    public GameObject Speed_Potion_Prefab;
    public GameObject Strength_Potion_Prefab;

    private bool isOpen;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        itemDrops.Add(HP_Potion_Prefab);
        itemDrops.Add(MP_Potion_Prefab);
        itemDrops.Add(Speed_Potion_Prefab);
        itemDrops.Add(Strength_Potion_Prefab);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isOpen)
            {
                OpenChest();
            }
        }
    }

    private void OpenChest()
    {
        _animator.SetBool("IsOpen", true);
        isOpen = true;
        ItemDrop();
    }

    private void ItemDrop()
    {
        //for(int i = 0; i < itemDrops.Count; i++)
        //{
        //    Instantiate(itemDrops[i], transform.position + new Vector3(0,0,0), Quaternion.identity);
        //}
        int randomPotion = Random.Range(0, itemDrops.Count);
        Instantiate(itemDrops[randomPotion], transform.position + new Vector3(0, 0, 0), Quaternion.identity);
    }
}
