using Godot;
using System;
using System.Collections.Generic;

public class Units : Node2D
{
    [Export]
    public KinematicBody2D[] playerUnits;
    int selectedUnity = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        playerUnits = new KinematicBody2D[GetChildCount()];

        for(int i = 0; i < playerUnits.Length; i++)
            playerUnits[i] = GetChild(i) as KinematicBody2D;
        
        foreach(var u in playerUnits)
        {
            if(u != null)
                GD.Print(u);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
