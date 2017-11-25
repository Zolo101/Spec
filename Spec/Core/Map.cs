using RLNET;
using RogueSharp;
using Thing.Core;
using Spec.Core;
using Spec.Interfaces;
using Spec;

// extend thing
public class DungeonMap : Map
{
    public static RLColor Wall = RLColor.LightGray;
    // draw thing map update
    // it'll render symbols and colors for the cell to the map
    public void Draw(RLConsole mapConsole)
    {
        mapConsole.Clear();
        foreach ( Cell cell in GetAllCells() )
        {
            SetConsoleSymbolForCell(mapConsole, cell);
        }
    }

    private void SetConsoleSymbolForCell (RLConsole console, Cell cell)
    {
        // only if we have explored it
        if (!cell.IsExplored)
        {
            return;
        }
        // draw it with lighter colors if its in the fov
        if ( IsInFov (cell.X, cell.Y) )
        {
            // choose the symbol to draw based on if the cell is walkable or not
            // . for floors and # for walls
            if (cell.IsWalkable)
            {
                console.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
            } else
            {
                console.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBackgroundFov, '#');
            }
        }
        // if a cell is outside draw it with darker colors
        else
        {
            if (cell.IsWalkable)
            {
                console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
            }
            else
            {
                console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
            }
        }
    }
    public void UpdatePlayerFieldOfView()
    {
        Player player = Program.Player;
        // Compute the field-of-view based on the player's location and awareness
        ComputeFov(player.X, player.Y, player.Awareness, true);
        // Mark all cells in field-of-view as having been explored
        foreach (Cell cell in GetAllCells())
        {
            if (IsInFov(cell.X, cell.Y))
            {
                SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
            }
        }
    }
    bool SetActorPosition( Actor actor, int x, int y)
    {

        // Only allow actor placement if the cell is walkable
        if (GetCell(x, y).IsWalkable)
        {
            // The cell the actor was previously on is now walkable
            SetIsWalkable(actor.X, actor.Y, true);
            // Update the actor's position
            actor.X = x;
            actor.Y = y;
            // The new cell the actor is on is now not walkable
            SetIsWalkable(actor.X, actor.Y, false);
            // Don't forget to update the field of view if we just repositioned the player
            if (actor is Player)
            {
                UpdatePlayerFieldOfView();
            }
            return true;
        }
        return false;
    }

    // A helper method for setting the IsWalkable property on a Cell
    public void SetIsWalkable(int x, int y, bool isWalkable)
    {
        Cell cell = GetCell(x, y);
        SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
    }
}