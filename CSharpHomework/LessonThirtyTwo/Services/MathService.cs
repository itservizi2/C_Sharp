﻿namespace LessonThirtyTwo.Services
{
    public class MathService : IMathService
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("Cannot divide by zero.");
            return a / b;
        }
    }

}
