using System;
using System.Collections.Generic;

namespace TextTowerProject
{
    public class TextTower
    {
        private readonly List<string> _tower;
        

        public TextTower()
        {
            this._tower = new List<string>();
            
        }

        public void Push(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new InvalidOperationException("You know you can't build a tower out of emptyness, right?");
            
            this._tower.Add(text);

            
        }

        public string Pop()
        {
            if(this._tower.Count == 0)
                throw new InvalidOperationException("Your tower is empty.");

            int index = this._tower.Count;
            string text = this._tower[index - 1];
            this._tower.Remove(text);

            

            return text;
        }

        public void Clear()
        {
            if (this._tower.Count > 4)
                throw new InvalidOperationException("Huh? An unexpected error has occurred.");

            this._tower.Clear();

            
        }
    }
}