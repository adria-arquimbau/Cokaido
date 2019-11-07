using System;

namespace GameOfLifeV2
{
    public class GameOfLife
    {
        private readonly Ecosystem _ecosystem;

        public GameOfLife(Ecosystem ecosystem)
        {
            _ecosystem = ecosystem;
        }

        public void Evolve()
        {
            _ecosystem.NewGeneration();
        }
    }
}