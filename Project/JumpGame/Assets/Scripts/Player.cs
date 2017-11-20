using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RoleBase {

protected override void Update()
    {
		base.Update();
		if (Input.GetKeyDown(KeyCode.A))
		{
			M_Dic = -1;
			speed = 1;
			Walk();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			M_Dic = 1;
			speed = 1;
			Walk();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
		if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
		{
			speed = 0;
		}

    }
}
