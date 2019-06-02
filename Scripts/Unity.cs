using Godot;
using System;

public class Unity : KinematicBody2D
{

    Units units;

    public override void _Ready()
    {
        units = GetNode("..") as Units;


    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
