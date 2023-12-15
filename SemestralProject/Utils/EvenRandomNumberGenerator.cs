using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which generates numbers with even distribution over orders.
    /// </summary>
    public class EvenRandomNumberGenerator: IEnumerable<int>
    {
        /// <summary>
        /// Minimum of generated numbers.
        /// </summary>
        private int minimum;

        /// <summary>
        /// Maximum of generated numbers.
        /// </summary>
        private int maximum;

        /// <summary>
        /// Limit of generated numbers.
        /// </summary>
        private int limit;

        /// <summary>
        /// Object with ability to generate random numbers.
        /// </summary>
        private Random random;

        /// <summary>
        /// Creates new random number generator with even distribution over orders.
        /// </summary>
        /// <param name="minimum">Minimum of generated numbers.</param>
        /// <param name="maximum">Maximum of generated numbers.</param>
        /// <param name="limit">Limit of generated numbers.</param>
        public EvenRandomNumberGenerator(int minimum, int maximum, int limit)
        {
            this.random = new Random();
            this.minimum = minimum;
            this.maximum = maximum;
            this.limit = limit;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int orderA = (int)Math.Floor(Math.Log10(this.minimum));
            int orderB = (int)Math.Floor(Math.Log10(this.maximum));

            int difference = Math.Abs(orderA - orderB);
            for (int i = 0; i < limit; i++)
            {
                int order = this.random.Next(orderA, orderB);
                double randomD = this.random.NextDouble();
                double reti = (double)Math.Pow(10, order) * randomD;
                yield return (int)Math.Round(reti);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
