using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    class Game
    {
        public Gameboard GB { get; set; }
        public int Time { get; set; }
        public List<Gameboard> GBSnapshots { get; set; }


        public Game(Gameboard gb = null, int time = 0)
        {
            this.GB = gb != null ? gb : new Gameboard();
            this.Time = time;
            this.GBSnapshots = new List<Gameboard>();
        }

        public int isDublicate()
        {
            if (GBSnapshots.Count() == 0)
                return -1;
            for (int i = 0; i < GBSnapshots.Count(); i++)
            foreach (var snapshot in GBSnapshots)
                if (this.GB.Equals(GBSnapshots[i]))
                    return i;
            return -1;
        }

        public void CountNextIteration()
        {
            this.GBSnapshots.Add(this.GB);
            this.Time++;
            var newGB = new Gameboard(this.GB.Height, this.GB.Width);
            for (int i = 0; i < this.GB.Height; i++)
            {
                for (int j = 0; j < this.GB.Width; j++)
                {
                    if (!this.GB.Board[i][j].IsAlive)
                    {
                        newGB.Board[i][j] = this.GB.getNeighboursStatuses(i, j) == 3 
                            ? new Cell(i, j, true) 
                            : new Cell(i, j, false);
                    }
                    else
                    {
                        newGB.Board[i][j] = this.GB.getNeighboursStatuses(i, j) < 2 
                            || this.GB.getNeighboursStatuses(i, j) > 3 
                            ? new Cell(i, j, false) 
                            : new Cell(i, j, true);
                    }
                }
        }
            this.GB = newGB;
        }

        public void Start(string path)
        {
            int dublicate = -1;
            while ((dublicate = isDublicate()) == -1)
            {
                WriteData(path);
                WriteData(path, false);
                CountNextIteration();
                Thread.Sleep(500);
            }
            WriteData(path, true, "This gameboard already happened on iteration " + dublicate + ".");
            WriteData(path, false, "This gameboard already happened on iteration " + dublicate + ".");
        }

        public void WriteData(string path = "", bool isConsole = true, string message = null)
        {
            if (isConsole)
            {
                Console.WriteLine("Iteration " + this.Time + ".");
                Console.WriteLine(GB.ToString());
                if (message != null)
                    Console.WriteLine(message);
            }
            else
            {
                if (!File.Exists(path))
                {
                    var fileStream = File.Create(path);
                    fileStream.Close();
                }
                using (var sw = File.AppendText(path))
                {
                    sw.WriteLine("Iteration " + this.Time + ".");
                    sw.WriteLine(GB.ToString());
                    if (message != null)
                        sw.WriteLine(message);
                }
            }
        }

    }
}
