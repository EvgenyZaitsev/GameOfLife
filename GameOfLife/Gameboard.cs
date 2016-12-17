using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Gameboard
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<List<Cell>> Board { get; set; }

        public Gameboard(int height = 0, int width = 0)
        {
            this.Height = height;
            this.Width = width;
            this.Board = new List<List<Cell>>();
            for (int i = 0; i < height; i++)
            {
                this.Board.Add(new List<Cell>());
                for (int j = 0; j < width; j++)
                    this.Board[i].Add(null);
            }
        }

        public void ReadData(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                try
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        if (this.Height == 0 || this.Width == 0)
                        {
                            var size = line.Split(' ').ToList();
                            this.Height = int.Parse(size.FirstOrDefault());
                            this.Width = int.Parse(size.LastOrDefault());
                            this.Board = new List<List<Cell>>();
                            for (int i = 0; i < this.Height; i++)
                            {
                                this.Board.Add(new List<Cell>());
                                for (int j = 0; j < this.Width; j++)
                                    this.Board[i].Add(null);
                            }
                        }
                    }
                    for (int i = 0; i < this.Height; i++)
                    {
                        line = sr.ReadLine();
                        var status = line.Split(' ').ToList();
                        for (int j = 0; j < this.Width; j++)
                        {
                            var currentStatus = int.Parse(status[j]);
                            this.Board[i][j] = new Cell(i, j, currentStatus != 0 ? true : false);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Problems while reading file. Try again!");
                }
            }
            
        }

        public void CreateData(int h = 10, int w = 10, double aliveChance = 0.5)
        {
            this.Height = h;
            this.Width = w;
            Random r = new Random();
            this.Board = new List<List<Cell>>();
            for (int i = 0; i < this.Height; i++)
            {
                this.Board.Add(new List<Cell>());
                for (int j = 0; j < this.Width; j++)
                    this.Board[i].Add(null);
            }
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    this.Board[i][j] = new Cell(i, j, r.NextDouble() < aliveChance ? true : false);
                }
            }
        }

        public List<List<Cell>> getCurrentBoard()
        {
            return new List<List<Cell>>(this.Board);
        }

        public int getNeighboursStatuses(int x, int y)
        {
            Cell c = this.Board[x][y];
            int statuses = 0;
            var xPos = c.XPosition;
            var yPos = c.YPosition;
            try
            {
                var neighbours = new List<Cell>() {
                    /*var topCell = */      this.Board[xPos == 0 ? this.Height - 1 : xPos - 1][yPos],
                    /*var botCell = */      this.Board[xPos == this.Height - 1 ? 0 : xPos + 1][yPos],
                    /*var leftCell = */     this.Board[xPos][yPos == 0 ? this.Width - 1 : yPos - 1],
                    /*var rightCell = */    this.Board[xPos][yPos == this.Width - 1 ? 0 : yPos + 1],
                    /*var topLeftCell = */  this.Board[xPos == 0 ? this.Height - 1 : xPos - 1][yPos == 0 ? this.Width - 1 : yPos - 1],
                    /*var topRightCell = */ this.Board[xPos == 0 ? this.Height - 1 : xPos - 1][yPos == this.Width - 1 ? 0 : yPos + 1],
                    /*var botLeftCell = */  this.Board[xPos == this.Height - 1 ? 0 : xPos + 1][yPos == 0 ? this.Width - 1 : yPos - 1],
                    /*var botRightCell = */ this.Board[xPos == this.Height - 1 ? 0 : xPos + 1][yPos == this.Width - 1 ? 0 : yPos + 1]
                };
                foreach (var cell in neighbours)
                    statuses += cell.IsAlive ? 1 : 0;
                return statuses;
            }
            catch (Exception e)
                {
                    Console.WriteLine(xPos + " " + yPos);
                    return -1;
                }
        }

        public override string ToString()
        {
            string board = "";
            for (int i = 0; i < this.Height; i++)
            {
                board += "| ";
                for (int j = 0; j < this.Width; j++)
                {
                    board += this.Board[i][j] + " | ";
                }
                board += Environment.NewLine;
            }
            return board;
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (var cells in this.Board)
                foreach (var cell in cells)
                    hashcode ^= cell.GetHashCode();
            return this.Height.GetHashCode() ^ this.Width.GetHashCode() ^ hashcode;
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Gameboard gb = obj as Gameboard;
            if (gb == null)
            {
                return false;
            }
            if ((this.Height == gb.Height) && (this.Width == gb.Width))
            {
                bool equals = true;
                for (int i = 0; i < this.Height; i++)
                {
                    for (int j = 0; j < this.Width; j++)
                        if (!(this.Board[i][j].IsAlive == gb.Board[i][j].IsAlive))
                        {
                            equals = false;
                            break;
                        }
                }
                return equals;
            }
            return false;
        }
    }
}
