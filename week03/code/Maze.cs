using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions))
            throw new InvalidOperationException("Invalid current position!");

        // directions[0] = left
        if (!directions[0])
            throw new InvalidOperationException("Can't go that way!");

        _currX -= 1;
    }

    public void MoveRight()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions))
            throw new InvalidOperationException("Invalid current position!");

        // directions[1] = right
        if (!directions[1])
            throw new InvalidOperationException("Can't go that way!");

        _currX += 1;
    }

    public void MoveUp()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions))
            throw new InvalidOperationException("Invalid current position!");

        // directions[2] = up
        if (!directions[2])
            throw new InvalidOperationException("Can't go that way!");

        _currY -= 1;
    }

    public void MoveDown()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions))
            throw new InvalidOperationException("Invalid current position!");

        // directions[3] = down
        if (!directions[3])
            throw new InvalidOperationException("Can't go that way!");

        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
