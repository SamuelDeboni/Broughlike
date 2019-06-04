using Godot;
using System;
using System.Collections.Generic;

public class Units : Node2D
{
    public Unity[] playerUnits;
    public int selectedUnity = 0;
    int unityCount = 0;
    public int turnCount;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        /*  get the amount of units,
            the units need to have index 0 
            to unity count */
        foreach(var c in GetChildren())
            if(c is Unity) unityCount++;

        playerUnits = new Unity[unityCount];

        for(int i = 0; i < playerUnits.Length; i++)
            playerUnits[i] = GetChild(i) as Unity;

        GD.Print("unityCount = " + unityCount);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Units movement
        if(selectedUnity < unityCount)
        {
            playerUnits[selectedUnity].GetNode<AnimatedSprite>("AnimatedSprite").Animation = "blink";
            
            if(Input.IsActionJustPressed("move_right"))
                playerUnits[selectedUnity].moveUnity(0);
            else if(Input.IsActionJustPressed("move_up"))
                playerUnits[selectedUnity].moveUnity(1);
            else if(Input.IsActionJustPressed("move_left"))
                playerUnits[selectedUnity].moveUnity(2);
            else if(Input.IsActionJustPressed("move_down"))
                playerUnits[selectedUnity].moveUnity(3);
        }
        else
            nextTurn();

    }

    void nextTurn()
    {
        selectedUnity = 0;
        foreach(var u in playerUnits)
        {
            u.moves = u.maxMoves;
        }
    }
}
