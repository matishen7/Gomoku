using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public class GameMode
    {
        private IScreen screen;
        private List<Tuple<string, IPlayerFactory>> factories = new List<Tuple<string, IPlayerFactory>>();

        public GameMode(IScreen screen)
        {
            this.screen = screen;

            foreach (var t in typeof(GameMode).Assembly.GetTypes())
            {
                if (typeof(IPlayerFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(t.Name.Replace("Factory", string.Empty),
                       (IPlayerFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public Player CreatePlayer(StoneColor color)
        {
            screen.Display("Choose from available players: ");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                screen.Display($"{i}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = screen.ReadLine()) != null
                    && int.TryParse(s, out int i)
                        && i >= 0
                        && i < factories.Count)
                    return factories[i].Item2.CreatePlayer(color, screen);
            }
            return null;
        }

    }
}
