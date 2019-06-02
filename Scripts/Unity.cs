using Godot;
using System;

public class Unity : KinematicBody2D
{
    Units units;
    Vector2 targetPos;


    public int moves = 1;

    public override void _Ready()
    {
        units = GetNode("..") as Units;
        targetPos = Position; 
    }

    public override void _Process(float delta)
    {
        // move the character

        if((Position-targetPos).Length() > 5)
            Position += (targetPos-Position)*0.5f;
        else
            Position = targetPos;       
    }


    public void moveUnity(int dir)
    {
        if(moves > 0)
        {
            switch (dir)
            {
                case 0:
                    RotationDegrees = 0;
                    if(!CollisionTest(targetPos + new Vector2(32,0)))
                        targetPos.x += 32;
                break;

                case 1:
                    RotationDegrees = 270;
                    if(!CollisionTest(targetPos - new Vector2(0,32)))
                        targetPos.y -= 32;
                break;

                case 2:
                    RotationDegrees = 180;
                    if(!CollisionTest(targetPos - new Vector2(32,0)))
                        targetPos.x -= 32;
                break;

                case 3:
                    RotationDegrees = 90;
                    if(!CollisionTest(targetPos + new Vector2(0,32)))
                        targetPos.y += 32;
                break;
            }
            moves--;
        }
        
        if(moves == 0)
        {
            units.selectedUnity++;
        }
    }

    /* Test if the unity will colide */
    bool CollisionTest(Vector2 pos)
    {
        foreach(var u in units.playerUnits)
        {
            var uk = u as KinematicBody2D;
            if(uk != null && uk.Position == pos)
                return true;
        }
        return false;
    }
}
