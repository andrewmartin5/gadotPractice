using Godot;
using System;

public class Sprite : Godot.Sprite
{

	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private int Speed = 400;
	private float AngularSpeed = Mathf.Pi;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Timer timer = GetNode<Timer>("Timer");
		timer.Connect("timeout", this, "_on_Timer_timeout");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Rotation += AngularSpeed * delta;
		var velocity = Vector2.Up.Rotated(Rotation) * Speed;

		Position += velocity * delta;
	}
	
	private void _on_Button_pressed()
	{
		SetProcess(!IsProcessing());
	}

	private void _on_Timer_timeout(){
		Visible = !Visible;
	}
}



