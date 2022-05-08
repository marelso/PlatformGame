using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
	Vector2 UP = new Vector2(0, -1);
	float grv = 10F;
	int walkspd = 100;
	float xspd = 0F;
	float yspd = 0F;
	int jumpHeight = -100;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var key_left = Convert.ToInt32(Input.IsActionPressed("ui_left"));
		var key_right = Convert.ToInt32(Input.IsActionPressed("ui_right"));
		var key_jump = Input.IsActionJustPressed("ui_up");
		var canJump = true;

		var move = key_right - key_left;
		xspd = move * walkspd;
		yspd += grv;

		if(IsOnFloor())
		{
			canJump = true;
			if(canJump && key_jump)
			{
				yspd = jumpHeight;
				canJump = false;
			}
		}
		Console.Write(yspd);
		var motion = new Vector2(xspd, yspd);
		motion = MoveAndSlide(motion, UP);
	}
}
