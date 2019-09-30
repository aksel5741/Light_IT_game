using System;


namespace Light_IT_GAME
{
    class Player
    {
        string name;
        int health;
        public Player() { name = "Computer";health = 100;}
        public Player(int health1) { health = health1; }
        public int Health{
            get{
                return health;
            }
            set
            {
                health = value;
            }
          }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
             name = value;
            }
        }
     }
}
