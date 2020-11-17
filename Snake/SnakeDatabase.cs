using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Snake
{
    public class SnakeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SnakeDatabase(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Score>().Wait();
        }

        // Score - retrieve / edit / delete / save

        public Task<List<Score>> GetScoresAsync()
        {
            return database.Table<Score>().ToListAsync();
        }
        public Task<Score> GetScoreAsync(int id)
        {
            return database.Table<Score>().Where(i => i.ScoreID == id).FirstOrDefaultAsync();
        }   
        public Task<Score> GetScoreAsync(string name)
        {
            return database.Table<Score>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }
        public Task<int> SaveScoreAsync(Score score)
        {
            if (score.ScoreID != 0)
            {
                return database.UpdateAsync(score);
            }
            else
            {
                return database.InsertAsync(score);
            }
        }
        public Task<int> DeleteScoreAsync(Score score)
        {
            return database.DeleteAsync(score);
        }  
    }
}
