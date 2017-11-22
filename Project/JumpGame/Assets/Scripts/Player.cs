using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RoleBase {

protected override void Update()
    {
		base.Update();
		M_Vec = Vector2.zero;
		if (Input.GetKey(KeyCode.A))
		{
			M_Vec = new Vector2(-1,0);
	
			Walk(M_Vec);
		}
		if (Input.GetKey(KeyCode.D))
		{
			M_Vec = new Vector2(1,0);
			
			Walk(M_Vec);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
		if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
		{
			Idle();
		}

    }
}
