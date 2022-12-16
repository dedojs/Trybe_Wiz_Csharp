using System;

namespace ShippingCalculator
{
    public class ShippingCalculator
    {
        /// <summary>
        /// This function evaluates the order price passed as an input parameter and returns the shipping price following the exercise's logic
        /// </summary>
        /// <param name="orderPrice"> A value of type double, the order price </param>
        /// <returns>The shipping price value (integer type), following the exercise logic </returns>
        /// <exception cref="ArgumentException">If the order price be equal to or less than zero</exception>
        public int CalculateShipping(double orderPrice) 
        {
            int result = 0;

            if (orderPrice <= 50) { result = 25; }
            if (orderPrice > 50) { result = 20; }
            if (orderPrice > 100) { result = 15; }
            if (orderPrice > 200) { result = 0; }

            if (orderPrice <= 0)
            {
                throw new Exception("The order price cannot be equal to or less than zero");
            }

            return result;
        }
    }
}
