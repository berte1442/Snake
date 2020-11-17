using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Snake
{
    public class Score
    {
        [PrimaryKey, AutoIncrement]
        public int ScoreID
        {
            get;
            set;
        }
        public int Points
        {
            get;
            set;
        }
        public string Name  // player's name
        {
            get;
            set;
        }
            

    }
}
