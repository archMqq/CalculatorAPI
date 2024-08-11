using org.mariuszgromada.math.mxparser;
using CalculatorAPI.Models;
using System.Data;

namespace CalculatorAPI.Service
{
    public interface ICalculationService
    {
        public double Add(double a, double b);
        public double Diff(double a, double b);
        public double Div(double a, double b);
        public double Multi(double a, double b);
        public double Pow(double numb, double degree);
        public double Root(double numb, double degree);
        public CalculationResult ExpressionSubstract(string expression);
    }

    public class CalculationService : ICalculationService
    {
        private readonly ILogger<CalculationService> _logger;

        public CalculationService (ILogger<CalculationService> logger)
        {
            _logger = logger;
        }

        public double Add(double a, double b) => a + b;

        public double Diff(double a, double b) => a - b;
        public double Div(double a, double b)
        {
            if (b == 0)
            {
                _logger.LogError("Ошибка деления на ноль (0) с числами: {a} и {b}", a, b);
                throw new DivideByZeroException("Деление на ноль (0) невозможно");
            }
                
            return a / b;
        }
        public double Multi(double a, double b) => a * b;
        public double Pow(double numb, double degree) => Math.Pow(numb, degree);
        public double Root(double numb, double degree)
        {
            if (degree == 0)
            {
                _logger.LogError("Ошибка взятия корня с числами: {numb} и {degree}", numb, degree);
                throw new ArgumentException("Корень по основанию ноль (0) не существует.");
            }
                
            return Math.Pow(numb, 1 / degree);
        }
        public CalculationResult ExpressionSubstract(string expression)
        {
            try
            {
                var expr = new Expression(expression);
                object result = expr.calculate();

                return new CalculationResult() { Result = Convert.ToDouble(result) };
            }
            catch (FormatException ex)
            {
                _logger.LogError(ex, "Ошибка формата с {expression}", expression);
                return new CalculationResult() { Error = ex.Message };
            }
            catch (EvaluateException ex)
            {
                _logger.LogError(ex, "Ошибка вычисления с {expression}", expression);
                return new CalculationResult() { Error = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неожиданная ошибка с {expression}", expression);
                return new CalculationResult() { Error = ex.Message };
            }
        }        
    }
}
