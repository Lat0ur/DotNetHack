﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack;
using DotNetHack.UI;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Affects;

namespace DotNetHack.Game
{
    /// <summary>
    /// GameEngine
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// GameEngine
        /// </summary>
        /// <param name="aPlayer"></param>
        public GameEngine(Player aPlayer, Dungeon3 aStartDungeon)
        {
            Time = 0L;
            Player = aPlayer;
            CurrentMap = aStartDungeon;
        }

        /// <summary>
        /// Run
        /// </summary>
        public void Run(EngineRunFlags aFlags)
        {
            Graphics.ShowGraphicsInfo();
            
            // set engine run flags
            RunFlags = aFlags;

            // CursorVisible
            Console.CursorVisible = false;

            // set to true for exit.
            bool done = false;

            while (!done)
            {

            redo_input:
                Graphics.CursorToLocation(1, 1); // So as not to pile up blanks.
                ConsoleKeyInfo input = Console.ReadKey();
                Location UnitMovement = new Location(0, 0);
                switch (input.Key)
                {
                    default:
                        continue;
                    case ConsoleKey.LeftArrow:
                        UnitMovement.X--; break;
                    case ConsoleKey.RightArrow:
                        UnitMovement.X++; break;
                    case ConsoleKey.UpArrow:
                        UnitMovement.Y--; break;
                    case ConsoleKey.DownArrow:
                        UnitMovement.Y++; break;
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                }
                if (!CurrentMap.CheckBounds(Player.Location + UnitMovement))
                    goto redo_input;


                Tile nPlayerTile = CurrentMap.GetTile(Player.Location + UnitMovement, Player.DungeonLevel);
                if (nPlayerTile != null)
                    if (nPlayerTile.TileType == TileType.WALL)
                        goto redo_input;

                Player.Location += UnitMovement;

                Update();

                CurrentMap.DungeonRenderer.Render(Player.Location, 0);

                Player.Draw();

                ++Time;
            }
        }

        public void Update()
        {
            UI.Graphics.Display.ShowStatsBar(Player.Stats);

            // WARNING
            #region Experimental Code Section

            var affPestilence = new Affects.Affect(Affects.AffectType.Disease, 5);

            affPestilence.Modifiers = AffectModifiers.Pestilence;

            Player.AffectStack.Push(affPestilence);

            Player.ResistanceStack.Push(new Affects.AffectResistance(Affects.AffectType.Disease, 20));

            Player.ApplyAffects();

            #endregion


#if OBSOLETE
            foreach (var iItem in CurrentMap.Items)
            {
                if (iItem.Location.Equals(Player.Location))
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 3);
                    Console.Write(iItem.Name);
                }
            }
#endif


            /*
            foreach (var m in World.Monsters)
            {
                if (m.Location.X < Player.Location.X)
                    m.Location.X++;
                if (m.Location.Y < Player.Location.Y)
                    m.Location.Y++;

                if (m.Location.Y > Player.Location.Y)
                    m.Location.Y--;
                if (m.Location.X > Player.Location.X)
                    m.Location.X--;
            }*/
        }

        /// <summary>
        /// Time
        /// </summary>
        public long Time { get; private set; }

        /// <summary>
        /// Player
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        // private Dictionary<DistantLocation, IItem> Items { get; set; }

        /// <summary>
        /// CurrentMap
        /// </summary>
        private Dungeon3 CurrentMap { get; set; }

        /// <summary>
        /// RunFlags
        /// </summary>
        public EngineRunFlags RunFlags { get; set; }

        /// <summary>
        /// EngineRunFlags
        /// </summary>
        [Flags]
        public enum EngineRunFlags { NORMAL, EDITOR, DEBUG }
    }
}