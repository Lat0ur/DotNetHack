﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Dungeon.Tiles;
using DotNetHack.Game;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Utility.Graph
{
    /// <summary>
    /// The basic node used for all DNH graph calculations.
    /// </summary>
    public class Node 
    {
        /// <summary>
        /// Creates an empty node.
        /// </summary>
        public Node() { }

        /// <summary>
        /// Creates a new DNH tile Node
        /// <remarks>The tile info and location are normally decoupled but are 
        /// brought together in this instance.</remarks>
        /// </summary>
        /// <param name="aTile">The tile information associated with this node</param>
        /// <param name="aLocation">The location of this node.</param>
        public Node(ITile aTile, Location3i aLocation) 
        {
            TileInfo = aTile;
            Location = aLocation;
        }

        /// <summary>
        /// Stores information about the tile.
        /// </summary>
        ITile TileInfo { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        Location3i Location { get; set; }

        /// <summary>
        /// Determines if the A* node is impassable.
        /// </summary>
        public bool Impassable
        {
            get { return TileInfo.Impassable; }
        }
    }
}