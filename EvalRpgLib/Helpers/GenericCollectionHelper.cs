using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Helpers
{
    public static class GenericCollectionHelper
    {

        /// <summary>
        /// Parcours un tableau à deux entrées, et appel une action avec les index i et j correspondant à l'état du parcours
        /// </summary>
        /// <typeparam name="T">Type contenu dans le tableau à deux entrées</typeparam>
        /// <param name="matrix">Le tableau à parcourir</param>
        /// <param name="action">L'action à appeler</param>
        public static void ForEachWithIndexes<T>(this T[,] matrix, Action<int,int> action)
        {
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    action(y, x);

                }
            }

        }

        /// <summary>
        /// Parcours un tableau à deux entrées, et appel une action avec l'object correspondant à l'état du parcours
        /// </summary>
        /// <typeparam name="T">Type contenu dans le tableau à deux entrées</typeparam>
        /// <param name="matrix">Le tableau à parcourir</param>
        /// <param name="action">L'action à appeler</param>
        public static void ForEachWithElement<T>(this T[,] matrix, Action<T> action)
        {
            ForEachWithIndexes(matrix, (int i, int j) => {
                action((T)matrix.GetValue(i, j));
            });
        }

        /// <summary>
        /// Ajoute une nouvelle valeur pour une clef, ou incrémente la valeur associée si elle existe déjà
        /// </summary>
        /// <typeparam name="T">Type de clef générique</typeparam>
        /// <param name="dictionary">un dictionnaire</param>
        /// <param name="key">Une clef du dictionnaire (existante ou non)</param>
        /// <param name="value">Une valeur à ajouter (ou incrémenter)</param>
        public static void AddOrIncrement<T>(this Dictionary<T, int> dictionary, T key, int value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] += value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}
