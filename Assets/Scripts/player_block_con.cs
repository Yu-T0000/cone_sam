using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class player_block_con : MonoBehaviour
{
    public GameObject python;
    private float input_x;
    public void OnDataReceived(uOSC.Message message)
    {
        if (message.address == "/move")
        {
            input_x = (float)message.values[0]/20;
            //-18~18の範囲
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        input_x = 0f;
        var client = python.GetComponent<uOscClient>();
        client.Send("/motorX","rst",00);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_pos = this.transform.position;
        Vector3 scale = this.transform.localScale;
        var scale_h = scale.x /2;

        player_pos.x = input_x;
        var pos_right = player_pos.x + scale_h;
        var pos_left = player_pos.x - scale_h;
       
        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
        rigidbody.MovePosition(player_pos);


    }
}
